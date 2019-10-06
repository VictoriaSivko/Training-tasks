namespace DAL.Interface.Interfaces
{
    public class Account
    {
        public int ID { get; set; }
        public double Balance { get; set; }
        public int PersonID { get; set; }
        public bool Open { get; set; }
        public int Bonus { get; set; }
    }
}
