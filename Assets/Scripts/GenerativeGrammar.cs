using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


public class GenerativeGrammar
{


    public static string Test()
    {


        var gram = new GenerativeGrammar();


        gram.Rules.Add(new Rule("w", "combat-item-w", null, 0.1f));


        gram.Rules.Add(new Rule("w", "combat-open_combat-w", null, 0.1f));




        gram.Rules.Add(new Rule("w", "combat", null, 0.2f));



        gram.Rules.Add(new Rule("w", "item", null, 0.2f));

        gram.Rules.Add(new Rule("w", "open_combat", null, 0.3f));


        gram.NoDup = new List<string> {"item"};

        /*gram.Check = (string f) => {
            var ar = f.Split("-");

            for(int truc = 0; truc < ar.Length - 1;truc++) {
                if(no.Contains(ar[truc]) && ar[truc] == ar[truc+1]) {
                    return false;
                }
            }

            return true;
        };*/

        



        return gram.All("start-w-item-end", new List<string> { "w" }, 10, 30);


    }


    public record Rule(String Input, String Output, Predicate<object>? Check = null, float Prob = 1.0f)
    {

    }

    public List<Rule> Rules { get; set; } = new List<Rule>();

    public List<String> NoDup {get;set;} = new List<string>();


    public Predicate<String>? Check {get;set;}


    bool NoDupli(string f) {
        var ar = f.Split("-");

            for(int truc = 0; truc < ar.Length - 1;truc++) {
                if(NoDup.Contains(ar[truc]) && ar[truc] == ar[truc+1]) {
                    return false;
                }
            }

            return true;
    }


    public string Next(string prev)
    {
        foreach (var r in Rules)
        {
            if (Rand.NextDouble() > r.Prob)
            {
                prev = prev.Replace("-"+r.Input+"-","-"+r.Output+"-");
            }
        }


        return prev;
    }


    public Random Rand {get;set;} = new Random();


    public string All(string start, List<string> toReplace, int min, int max)
    {



        string data = start;

        int next = Rand.Next(min,max-1);

        while (data.Count((c) => c == '-') < next)
        {


            data = start;

            while (toReplace.Any((dt) => data.Contains("-"+dt+"-")))
            {


                var dt = this.Next(data);

                if((Check == null || Check.Invoke(dt)) && NoDupli(dt)) {
                    data = dt;
                }

                if (Rand.NextDouble() < 0.1)
                {
                    break;
                }
            }

            if (Rand.NextDouble() < 0.1)
            {
                break;
            }
        }


        return data;
    }


}