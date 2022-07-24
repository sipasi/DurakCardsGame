using System.Reflection;

using NUnit.Framework;

namespace ProjectCard.Editor.TestModule.ToolModule
{
    public static class TypeExtension
    {
        public static T GetPrivateField<T, TObject>(this TObject from, string name)
        {
            var type = typeof(TObject);

            var field = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.IsNotNull(field);

            var value = field.GetValue(from);

            Assert.IsNotNull(value);

            var result = (T)value;

            Assert.IsNotNull(value);

            return result;
        }
        public static void SetPrivateField<T, TObject>(this TObject to, string name, T value)
        {
            var type = typeof(TObject);

            var field = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.IsNotNull(field, $"The field by name[{name}] not exist. Object type[{typeof(TObject)}]");

            field.SetValue(to, value);
        }
    }
}