using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly_ChapterTwo
{
    public class Counter
    {
        public string Name
        {
            get { return _name;  }
            set { _name = value; }
            
        }
        private string _name;

        public readonly string ReadOnlyMember;
        public readonly string Id;
        public static readonly string ReadOnlyStaticMember = "Static Read Only Member";

        private int _count = 0;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        // Never changing, static variable
        public const int ConstantStaticNumber = 12;

        public int Increment()
        {
            int count = ++_count;

            return count;
        }

        public Counter()
        {
            this.ReadOnlyMember = "default value of read only member";
            this._name = "Billy";
        }
        public Counter(int count): this()
        {
            this.Count = count;
        }
        public Counter(string id): this(23)
        {
            this.Id = id;
        }
    }
}
