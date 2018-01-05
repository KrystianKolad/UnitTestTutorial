using System.Collections.Generic;

namespace UnitTestTutorial.Model {
    public class User : Entity {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Money { get; set; }
        public IList<Product> TransactionHistory { get; set; }
        public int UserType { get; set; }
    }
}