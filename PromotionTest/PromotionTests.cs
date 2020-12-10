using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionTest
{
    [TestClass]
    public class PromotionTests
    {
        IInventory Inventory { get; set; }
        IPromotions Promotions { get; set; }
        List<Item> Items { get; set; } = new List<Item>();

        [TestInitialize]
        public void TestInIt()
        {           
            Items.Add(new Item() { UnitId = 'A', Price = 50 });
            Items.Add(new Item() { UnitId = 'B', Price = 30 });
            Items.Add(new Item() { UnitId = 'C', Price = 20 });
            Items.Add(new Item() { UnitId = 'D', Price = 15 });

            // Add inventory
            Inventory = new Inventory();
            Inventory.AddSKUs(Items[0]);
            Inventory.AddSKUs(Items[1]);
            Inventory.AddSKUs(Items[2]);
            Inventory.AddSKUs(Items[3]);

            // Add Promotions
            Promotions = new Promotion();
            Promotions.AddPromotion(Items[0], 3, 20);
            Promotions.AddPromotion(Items[1], 2, 15);
            Promotions.AddPromotion(Items[2], Items[3], 5);
        }

        [TestMethod]
        public void ScenarioATest()
        {            
            ICart cart = new Cart(Inventory, Promotions);

            cart.AddToCart(Items[0], 1);
            cart.AddToCart(Items[1], 1);
            cart.AddToCart(Items[2], 1);
            cart.ApplyPromotion();
            Assert.AreEqual(100, cart.TotalCost);
        }

        [TestMethod]
        public void ScenarioBTest()
        {
            ICart cart = new Cart(Inventory, Promotions);

            cart.AddToCart(Items[0], 5);
            cart.AddToCart(Items[1], 5);
            cart.AddToCart(Items[2], 1);
            cart.ApplyPromotion();
            Assert.AreEqual(370, cart.TotalCost);
        }

        [TestMethod]
        public void ScenarioCTest()
        {
            ICart cart = new Cart(Inventory, Promotions);

            cart.AddToCart(Items[0], 3);
            cart.AddToCart(Items[1], 5);
            cart.AddToCart(Items[2], 1);
            cart.AddToCart(Items[3], 1);
            cart.ApplyPromotion();
            Assert.AreEqual(280, cart.TotalCost);
        }

    }
}
