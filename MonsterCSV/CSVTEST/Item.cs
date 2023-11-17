namespace TestCSV
{
    public class Item
    {
        public int id;
        public string name;
        public string comment;
        public int price;
        public bool isOverlap;

        public Item(string myId, string myName, string myComment, string myPrice, string myOverlap)
        {
            id = int.Parse(myId);

            name = myName;
            comment = myComment;
            
            price = int.Parse(myPrice);

            isOverlap = (myOverlap.ToString() == "true") ? true : false;
        }
   
    }
}

  