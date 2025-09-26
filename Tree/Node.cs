namespace Tree
{
    internal class Node
    {
        public Person Value { get; set; }      // Данные
        public Node Left { get; set; }         // Левое поддерево
        public Node Right { get; set; }        // Правое поддерево

        public Node(Person value = null, Node left = null, Node right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
