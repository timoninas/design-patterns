
namespace Visitor
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            FakeDB db = new FakeDB();

            db.Add(new Person("Anton Timonin", 2700));
            db.Add(new Person("Gergor Timonin", 0));
            db.Add(new Company("RNA Bank", 17, 27000));
            db.Add(new Person("Digo Eldigo", 800));

            db.ShowFormateInfo(new ToJson());
            db.ShowFormateInfo(new ToXml());
        }
    }
}

    // OUTPTUT
    // {
    //     "name": Anton Timonin,
    //     "account": 2700
    // }

    // {
    //     "name": Gergor Timonin,
    //     "account": 0
    // }

    // {
    //     "name": RNA Bank,
    //     "number_of_employees": 17,
    //     "company_statement": 27000
    // }

    // {
    //     "name": Digo Eldigo,
    //     "account": 800
    // }

    // <article lang = "" >
    // < para > Person name: Anton Timonin</para>
    // <para>Account: 2700</para>
    // </article>

    // <article lang = "" >
    // < para > Person name: Gergor Timonin</para>
    // <para>Account: 0</para>
    // </article>

    // <article lang = "" >
    // < para > Company name: RNA Bank</para>
    // <para>Number of Employees: 17</para>
    // <para>Company statement: 27000</para>
    // </article>

    // <article lang = "" >
    // < para > Person name: Digo Eldigo</para>
    // <para>Account: 800</para>
    // </article>
