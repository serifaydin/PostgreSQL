using System;

namespace PostgreSQL.Entities
{
    public class tbluser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}