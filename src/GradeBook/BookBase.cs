namespace Gradebook
{
    public abstract class BookBase : NamedObject, IBook
    {
        protected BookBase(string name) : base(name) { }

        public virtual event GradeAddedDelegate GradeAdded;

        //I cannot provide an implementation yet, so abstract
        public abstract void AddGrade(double grade);
        //may choose to override the abstact method
        public virtual Statistics GetStatistics()
        {
            throw new System.NotImplementedException();
        }
    }
}