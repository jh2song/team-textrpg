namespace TestCSV
{
    internal class Data
    {

        /*
        path엔 경로명\\파일명

        예) 내문서위치
         string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        "파일명.확장자"만 쓰면 프로젝트 폴더 속 bin\Debug\net6.0 폴더 안에 파일을 넣어놔야합니다.

         */


        public static Dictionary<int, Item> itemData;

        public static string path = "ItemData.csv"; //파일경로

        public static void Init()
        {
            itemData = new Dictionary<int, Item>();
            itemData.Clear();

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    sr.ReadLine(); // 헤더날리는 용

                    while (!sr.EndOfStream) //마지막줄이 아닐 때
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(','); // , 에서 자르고 배열에넣기

                        Item item = new Item(data[0], data[1], data[2], data[3], data[4]); // 전부 string이기 때문에 사용하기 전에 형변환 시켜줘야합니다!
                        itemData.Add(item.id, item);
                    }
                }
            }
        }
    }
}
