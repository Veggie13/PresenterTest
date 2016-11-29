using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PresenterTest
{
    interface ITestPresenterItem : IPresenterItem<TestObject>
    {
        [DisplayName("Object Name")]
        string ObjectName { get; }

        [DisplayName("Description")]
        string Desc { get; }

        [DisplayName("Data Type")]
        string DataType { get; }
    }

    class TestPresenterItem : BasePresenterItem<TestObject>, ITestPresenterItem
    {
        public TestPresenterItem(TestObject obj)
            : base(obj)
        {
        }

        public string ObjectName
        {
            get { return Item.Name; }
        }

        public string Desc
        {
            get { return Item.Desc; }
        }

        public string DataType
        {
            get
            {
                switch (Item.Type)
                {
                    case TestObject.eType.T1:
                        return "Type1";
                    case TestObject.eType.T2:
                        return "Type2";
                    case TestObject.eType.T3:
                        return "Type3";
                    default:
                        throw new InvalidEnumArgumentException();
                }
            }
        }
    }
}
