using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace KeyValueMapping.ViewModels
{
    public class ViewModelBase<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged<R>(Expression<Func<T, R>> x)
        {
            var body = x.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("'x' should be a member expression");

            string propertyName = body.Member.Name;

            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
