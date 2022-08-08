using System;

namespace Ch07Ex02
{
    internal class Program
    {
        static string[] eTypes = { "none", "simple", "index", "nested index", "filter" };

        static void Main(string[] args)
        {
            foreach (string eType in eTypes)
            {
                try
                {
                    Console.WriteLine("Main() try block reached.");
                    Console.WriteLine($"ThrowException(\"{eType}\") called.");
                    ThrowException(eType);
                    Console.WriteLine("Main() try block continues.");
                }
                catch (System.IndexOutOfRangeException e) when (eType == "filter")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Main() FILTERED System.IndexOutOfRangeException" +
                                      $"catch block reached. Message: \n\"{e.Message}\"");
                    Console.ResetColor();
                }
                catch (System.IndexOutOfRangeException e)
                {
                    Console.WriteLine("Main() System.IndexOutOfRangeException catch " +
                                      $"block reached. Message \n\"{e.Message}\"");
                }
                catch
                {
                    Console.WriteLine("Main() general catch block reached.");
                }
                finally
                {
                    Console.WriteLine("Main() finally block reached.");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void ThrowException(string exceptionType)
        {
            Console.WriteLine($"ThrowException(\"{exceptionType}\") reached.");
            switch(exceptionType)
            {
                case "none":
                    Console.WriteLine("Not throwing an exception.");
                    break;
                case "simple":
                    Console.WriteLine("Throwing System.Exception.");
                    throw new System.Exception();
                case "index":
                    Console.WriteLine("Throwing System.IndexOutOfRangeException.");
                    eTypes[5] = "error";
                    break;
                case "nested index":
                    try
                    {
                        Console.WriteLine("ThrowException(\"nested index\") " +
                                          "try block reached.");
                        Console.WriteLine("ThrowException(\"index\" called.");
                        ThrowException("index");
                    }
                    
                    
                    
                    
                    
                    catch
                    {
                        Console.WriteLine("ThrowException(\"nested index\") general"
                                          + " catch block reached.");
                        throw;
                    }
                    finally
                    {
                        Console.WriteLine("ThrowException(\"nested index\") finally"
                                          + " block reached.");
                    }
                    break;

                case "filter":
                    try
                    {
                        Console.WriteLine("ThrowException(\"filter\") " +
                                          "try block reached.");
                        Console.WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");
                    }
                    catch
                    {
                        Console.WriteLine("ThrowException(\"filter\") general"
                                          + " catch block reached");
                        throw;
                    }
                    break;
            }
        }
    }
}
