using BreedFoodStoreListopad.Domain.Entities;
using BreedFoodStoreListopad.Domain.Exceptions;

namespace BreedFoodStoreListopad.Tests.Domain
{
	/// <summary>
	/// Проверка сущьности "Категория"
	/// </summary>
	public class CategoryTests
	{
		/// <summary>
		/// Сравнить две коллекции
		/// </summary>
		/// <typeparam name="T">Тип данных в коллекции</typeparam>
		/// <param name="list1">Первая коллекция</param>
		/// <param name="list2">Вторая коллекция</param>
		void EnumerableEqual<T>(IEnumerable<T> list1, IEnumerable<T> list2)
		{
			var en1 = list1.GetEnumerator();
			var en2 = list2.GetEnumerator();
			bool moveNext1 = en1.MoveNext();
			bool moveNext2 = en2.MoveNext();

			while (moveNext1 || moveNext2)
			{
				Assert.Equal(en1.Current, en2.Current);
				moveNext1 = en1.MoveNext();
				moveNext2 = en2.MoveNext();
			}

			Assert.Equal(moveNext1, moveNext2);
		}

		/// <summary>
		/// Проверка установки имени
		/// </summary>
		[Fact]
		public void TestSetName()
		{
			// Подготовка
			Category category = new Category();
			string nameHelper1, nameHelper2, nameHelper3;
			List<string> listHelper1, listHelper2, listHelper3;

			// Действие
			category.Name = "Test1";
			nameHelper1 = category.Name;
			listHelper1 = new List<string>(category.OldNames);

			category.Name = "Test2";
			nameHelper2 = category.Name;
			listHelper2 = new List<string>(category.OldNames);

			// Утверждение
			Assert.Equal("Test1", nameHelper1);
			EnumerableEqual(new string[] { }, listHelper1);
			Assert.Equal("Test2", nameHelper2);
			EnumerableEqual(new string[] { "Test1" }, listHelper2);
		}

		/// <summary>
		/// Проверка установки старого имени
		/// </summary>
		[Fact]
		public void TestSetOldName()
		{
			// Подготовка
			Category category = new Category();
			string nameHelper1, nameHelper2, nameHelper3;
			List<string> listHelper1, listHelper2, listHelper3;

			// Действие
			category.Name = "Test1";
			category.Name = "Test2";
			category.Name = "Test3";
			category.Name = "Test4";

			category.SetOldName(0);
			nameHelper1 = category.Name;
			listHelper1 = new List<string>(category.OldNames);

			category.SetOldName(2);
			nameHelper2 = category.Name;
			listHelper2 = new List<string>(category.OldNames);

			category.Name = "Test5";
			category.Name = "Test6";
			category.SetOldName(3);
			nameHelper3 = category.Name;
			listHelper3 = new List<string>(category.OldNames);

			// Утверждение
			Assert.Equal("Test1", nameHelper1);
			EnumerableEqual(new string[] { "Test2", "Test3", "Test4" }, listHelper1);
			Assert.Equal("Test4", nameHelper2);
			EnumerableEqual(new string[] { "Test2", "Test3", "Test1" }, listHelper2);
			Assert.Equal("Test4", nameHelper3);
			EnumerableEqual(new string[] { "Test2", "Test3", "Test1", "Test5", "Test6" }, listHelper3);
		}

		/// <summary>
		/// Проверка ловли исключений
		/// </summary>
		[Fact]
		public void TestException()
		{
			// Подготовка
			Category category = new Category();
			string helpString;
			Exception exceptionhelper1 = null, exceptionhelper2 = null, exceptionhelper3 = null, 
				exceptionhelper4 = null, exceptionhelper5 = null;

			// Действие
			try
			{
				helpString = category.Name;
			}
			catch (Exception ex)
			{
				exceptionhelper1 = ex;
			}

			try
			{
				category.SetOldName(0);
			}
			catch (Exception ex)
			{
				exceptionhelper2 = ex;
			}

			try
			{
				category.Name = "Test1";
				category.SetOldName(0);
			}
			catch (Exception ex)
			{
				exceptionhelper3 = ex;
			}

			try
			{
				category.Name = "Test2";
				category.Name = "Test3";
				category.SetOldName(10);
			}
			catch (Exception ex)
			{
				exceptionhelper4 = ex;
			}

			try
			{
				category.SetOldName(-1);
			}
			catch (Exception ex)
			{
				exceptionhelper5 = ex;
			}

			// Утверждение
			Assert.True(exceptionhelper1 is CategoryHasNoNameException);
			Assert.True(exceptionhelper2 is RequiredOldNameNotFoundException);
			Assert.True(exceptionhelper3 is RequiredOldNameNotFoundException);
			Assert.True(exceptionhelper4 is RequiredOldNameNotFoundException);
			Assert.True(exceptionhelper5 is RequiredOldNameNotFoundException);
		}
	}
}
