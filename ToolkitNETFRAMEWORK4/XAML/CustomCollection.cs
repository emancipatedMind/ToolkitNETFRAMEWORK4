namespace ToolkitNFW4.XAML {
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using ToolkitNFW4.EventArgs;

    public class CustomCollection<T> : IEnumerable<T> {
        public event EventHandler<GenericCollectionEventArgs<T>> CollectionAddedTo;
        public event EventHandler CollectionCleared;

        List<T> _collection = new List<T>();

        public void Clear() {
            _collection.Clear();
            CollectionCleared?.Invoke(this, new System.EventArgs());
        }

        public void AddRange(IEnumerable<T> range) {
            _collection.AddRange(range);
            CollectionAddedTo?.Invoke(this, new GenericCollectionEventArgs<T>(range));
        }

        public IEnumerator<T> GetEnumerator() =>
            _collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _collection.GetEnumerator();
    }
}
