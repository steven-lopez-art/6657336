using _6657336.Data;
using _6657336.Models;
namespace _6657336.Views;

[QueryProperty("Item", "Item")]

public partial class TodoItemPage : ContentPage
{

    TodoItem item;

    public TodoItem Item
    {
        get => BindingContext as TodoItem;
        set => BindingContext = value;
    }

    TodoItemDatabase database;

    public TodoItemPage(TodoItemDatabase todoItemDatabase)
    {
        InitializeComponent();
        database = todoItemDatabase;
    }

    async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Nombre Requerido", "Introduzca un nombre para el elemento de tareas pendientes.", "OK");
            return;
        }
        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void Button_Clicked_1(object sender, EventArgs e)
    {
        if (Item.Id == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}