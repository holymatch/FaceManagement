using WebEntity;

namespace RestfulClient
{
    class Person
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public Face Face { get; set; }

        public Person(string name, string detail, Face face)
        {
            //this.id = null;
            this.Name = name;
            this.Detail = detail;
            this.Face = face;
        }
    }
}
