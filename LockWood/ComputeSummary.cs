using System;
using System.Collections.Generic;
using LockWood.Models;
using UIKit;

namespace LockWood
{
    public class ComputeSummary
    {
        public ComputeSummary()
        {

        }

        public void getSummary(List<Transaction> transactions, UITextView textView)
        {
            List<String> textToPrint = new List<string>();

            List<Transaction> stockPileList = new List<Transaction>();
            while (transactions.Count > 0)
            {
                stockPileList.Clear();
                string source = transactions[0].GetSource();
                textToPrint.Add("\n");
                textToPrint.Add("Source = " + source);

                for (int i = 0; i < transactions.Count; i++)
                {
                    if (transactions[i].GetSource() == source)
                    {
                        stockPileList.Add(transactions[i]);
                    }
                }
                for (int i = 0; i < stockPileList.Count;i++){
                    RemoveMethod(transactions, stockPileList[i]);
                }

                /*  for (int i = 0; i < transactions.Count; i++)
                  {
                      if (transactions[i].GetSource() == source)
                      {
                          stockPileList.Add(transactions[i]);
                      }
                  }

                for (int i = 0; i < transactions.Count; i++)
                {

                    for (int j = 0; j < transactions.Count; j++)
                    {

                        if (transactions[j].GetSource() == source)
                        {

                            transactions.Remove(transactions[j]);
                        }

                    }
                }*/



                while (stockPileList.Count > 0)
                {
                    double grossWeight = 0;
                    double tareWeight = 0;
                    double tons = 0;
                    int loads = 0;
                    string stockpile;


                    stockpile = stockPileList[0].GetDestination();

                    textToPrint.Add("\n");
                    textToPrint.Add("Stockpile = " + stockpile + "\n");
                    foreach (var b in stockPileList)
                    {
                        if (b.GetDestination() == stockpile)
                        {
                            grossWeight += Double.Parse(b.GetGrossWeight());
                            tareWeight += Double.Parse(b.GetTareWeight());
                            loads++;
                        }
                    }

                    tons = (grossWeight - tareWeight) / 2000;
                    textToPrint.Add("Tons = " + tons + "\n");
                    textToPrint.Add("Loads = " + loads + "\n");

                    //for (int i = 0; i < stockPileList.Count; i++)
                    for (int i = stockPileList.Count; i > 0; i--)
                    {
                        for (int j = 0; j < stockPileList.Count; j++)
                        {
                            if (stockPileList[j].GetDestination() == stockpile)
                            {
                                stockPileList.Remove(stockPileList[j]);

                            }
                        }
                    }

                    loads = 0;
                    grossWeight = 0;
                    tareWeight = 0;
                    tons = 0;

                }
            }
            foreach (var c in textToPrint)
            {

                textView.InsertText(c);
            }

        }
        public void RemoveMethod(List<Transaction> transactions, Transaction transactionToRemove)
        {
            transactions.Remove(transactionToRemove);
        }
    }

}
