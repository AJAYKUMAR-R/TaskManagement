using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Classes.designPattern.dependencyContainers
{
    public class DependecyInjection
    {
        //I am creating the Dictonary for storing all the Type and concrete
        //class
        private Dictionary<Type, List<object>> instances = new Dictionary<Type, List<object>>();

        //here i am registering the service 
        //and Defining the Type Constarint
        //without new it considered as value Type object like int,long
        public void Register<IResult, IImplementation>() where IImplementation : IResult, new()
        {
            //First checking the whether the Type is there or not
            //if it is there geting the list out and adding the new instance 
            //in that family to achive poly morphism
            if (instances.TryGetValue(typeof(IResult), out var list))
            {
                list.Add(new IImplementation());
            }
            else
            {
                //if not creating the new list and dding the first object
                List<object> implementations = new List<object>();
                implementations.Add(new IImplementation());
                instances[typeof(IResult)] = implementations;
            }

        }

        public TResult Resolve<TResult, Implementation>()
        {
            //checking the key is there or not the will throw erorr if not
            if (instances.TryGetValue(typeof(TResult), out var instant))
            {
                if (instant is not null)
                {
                    foreach (var item in instant)
                    {
                        //The list will iterated to find the instance and return it
                        if (typeof(Implementation) == item.GetType())
                        {
                            return (TResult)item;
                        }
                        else
                        {
                            throw new Exception($"Instance not Found {typeof(Implementation)}");
                        }
                    }
                }

            }

            throw new Exception($"Invalid Given Type {typeof(TResult)} not Registered");
        }
    }
}
