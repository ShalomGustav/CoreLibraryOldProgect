using CoreLibrary.Interfaces;
using CoreLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreLibrary.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private string FileName;
        
        public void SetFileName(string fileName)
        {
            FileName = fileName;
        }

        public AuthorizationResponce GetAccount(Credentials credentials)
        {
            var accounts = GetAccounts();

            if (accounts != null)
            {
                var found = accounts.Clients.FirstOrDefault(x => x.UserName == credentials.Client.UserName);

                if (found != null)
                {
                    return new AuthorizationResponce
                    {
                        Success = true,
                        Client = found
                    };
                };

                return new AuthorizationResponce
                {
                    Success = false,
                    Errors = new List<Error>
                    {
                        new Error
                        {
                            Cod = "2",
                            Message = "User not found",
                            Target = nameof(GetAccount)
                        }
                    }
                };
            }
            
            return new AuthorizationResponce
            {
                Errors = new List<Error>
                {
                    new Error
                    {
                        Cod = "1",
                        Message = "Accounts not found",
                        Target = nameof(GetAccount)
                    }
                }
            };
            
        }

        public AuthorizationResponce UpdateAccount(Credentials credentials)
        {
            var accounts = GetAccounts();

            if (accounts != null)
            {
                var found = accounts.Clients.FirstOrDefault(x => x.UserName == credentials.Client.UserName);

                if (found != null)
                {
                    var key = found.Key;

                    credentials.Client.Key = key;

                    accounts.Clients.Remove(found);

                    accounts.Clients.Add(credentials.Client);
                };
            }

            if (accounts == null)
            {
                return new AuthorizationResponce
                {
                    Errors = new List<Error>
                    {
                        new Error
                        {
                            Cod = "1",
                            Message = "Accounts not found",
                            Target = nameof(UpdateAccount)
                        }
                    }
                };
            }

            using (StreamWriter writer = File.CreateText(FileName))
            {
                string output = JsonConvert.SerializeObject(accounts);
                writer.Write(output);
            }

            return new AuthorizationResponce
            {
                Success = true,
                Client = credentials.Client
            };
        }

        public AuthorizationResponce Register(Credentials credentials)
        {
            var accounts = GetAccounts();

            if(accounts != null)
            {
                var found = accounts.Clients.FirstOrDefault(x => x.UserName == credentials.Client.UserName);

                if (found != null)
                {
                    return new AuthorizationResponce
                    {
                        Success = false,
                        Errors = new List<Error>()
                        {
                            new Error
                            {
                                Cod = "R1",
                                Message = "User exist",
                                Target = nameof(Register)
                            }
                        }
                    };
                }
            }

            if(accounts == null)
            {
                accounts = new Accounts();
            }                  

            var client = credentials.Client;
            client.Key = Guid.NewGuid().ToString();

            if(accounts.Clients == null)
            {
                accounts.Clients = new List<Client>();
            }
                        
            accounts.Clients.Add(client);

            using (StreamWriter writer = File.CreateText(FileName))
            {
                string output = JsonConvert.SerializeObject(accounts);
                writer.Write(output);
            }

            return new AuthorizationResponce
            {
                Success = true,
                Client = client
            };
        }

        public AuthorizationResponce Authorization(Credentials credentials)
        {
            var accounts = GetAccounts();

            if (accounts == null)
            {
                return new AuthorizationResponce
                {
                    Success = false,
                    Client = credentials.Client,
                    Errors = new List<Error>()
                    {
                        new Error
                        {
                            Cod = "1",
                            Message = "Accounts not found",
                            Target = nameof(Authorization)
                        }
                    }
                };
            }

            var found = accounts.Clients.FirstOrDefault(x => x.UserName == credentials.Client.UserName);

            if(found == null)
            {
                return new AuthorizationResponce
                {
                    Success = false,
                    Client = credentials.Client,
                    Errors = new List<Error>()
                    {
                        new Error
                        {
                            Cod = "2",
                            Message = "User not found",
                            Target = nameof(Authorization)
                        }
                    }
                };
            }

            if(found.Password == credentials.Client.Password)
            {
                found.Password = "";

                return new AuthorizationResponce
                {
                    Success = true,
                    Client = found

                };
            }
            else
            {
                return new AuthorizationResponce
                {
                    Success = false,
                    Client = credentials.Client,
                    Errors = new List<Error>()
                    {
                        new Error
                        {
                            Cod = "3",
                            Message = "Password is't correct",
                            Target = nameof(Authorization)
                        }
                    }
                };
            }
        }

        private Accounts GetAccounts()
        {
            Accounts accounts;
            try
            {
                accounts = JsonConvert.DeserializeObject<Accounts>(File.ReadAllText(FileName));
            }
            catch
            {
                return null;
            }

            return accounts;
        }
    }

}
