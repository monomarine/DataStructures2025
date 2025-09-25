using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal sealed class Student : IEquatable<Student>
    {
        public string Id { get; }
        public string Name { get; }

        public Student(string id, string name)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("требуется идентификатор", nameof(id));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("требуется имя", nameof(name));
            Id = id.Trim();
            Name = name.Trim();
        }
        public bool Equals(Student other) => other is not null && Id == other.Id;
        public override bool Equals(object obj) => Equals(obj as Student);
        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => $"{Name} ({Id})";
    }
}
