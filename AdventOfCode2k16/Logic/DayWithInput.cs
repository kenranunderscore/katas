namespace Logic
{
    public abstract class DayWithInput<T>
    {
        protected readonly T input;

        public DayWithInput(T input)
        {
            this.input = input;
        }
    }
}