namespace zehreken.i_cheat.MiniBus
{
	public abstract class Bindable<TObj, TValue>
	{
		protected TObj obj;

		public Bindable(TObj obj)
		{
			this.obj = obj;
		}

		public abstract void Update(TValue value);

		public bool Equals(Bindable<TObj, TValue> other)
		{
			return (object) obj == (object) other.obj;
		}
	}
}