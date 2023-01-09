using System;

namespace Satistics_API_client
{
    public class ConfigurationManager
    {
        public string  this[string index]
        {
            get 
            { 
                return "http://localhost:4449/"; 
            }
            
        }
    }
}