using System;

namespace Supermarket.Models
{
    public class Groceries
    {
        public int id { get; set; }
        public string measurementType { get; set; }
        public string name { get; set; }
        public DateTime expirationDate { get; set; }
        public int quantity { get; set; }
        public string imageURL { get; set; }
        public string description { get; set; }
    }
}
/*
export interface Grocery
{
    id:number;
    measurementType:String;
    name: String;
    expirationDate: Date;
    quantity: number;
    imageURL: String;
    description: String;
}*/