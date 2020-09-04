namespace Gradebook
{
    public abstract class BookBase : NamedObject
    {
        protected BookBase(string name) : base(name)
        { }

        //I cannot provide an implementation yet, so abstract
        public abstract void AddGrade(double grade);
    }
}