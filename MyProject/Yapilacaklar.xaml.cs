using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MyProject;

public partial class Yapilacaklar : ContentPage
{


    public Yapilacaklar()
    {

       
		InitializeComponent();

        if (File.Exists(filename) )
        {
           
            String data = File.ReadAllText(filename);
            contacts = JsonSerializer.Deserialize<ObservableCollection<Contact>>(data);
        }
   	   veiw.ItemsSource = contacts;
       
  }
	public ObservableCollection<Contact> Contacts => contacts;

    

    ObservableCollection<Contact> contacts = new ()
	{
     new Contact(){Vize ="Sinav"},
    
   
   };

    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        EklePage page = new EklePage() { Title ="Not Ekle", AddMethod =AddContact};
       await Navigation.PushAsync(page);
      
    }
    public void AddContact (Contact contact)
    {
        Contacts.Add(contact);
    }

    private async void EditComand_Clicked(object sender, EventArgs e)
    {
        var but = sender as ImageButton;
        var Ekle = Contacts.Single(o => o.ID == but.CommandParameter.ToString());


        EklePage page = new EklePage() { Title = "Not Düzenle ", Ekle=Ekle};
        await Navigation.PushAsync(page);
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {

        var but = sender as ImageButton;
        var ekle = Contacts.Single(o => o.ID == but.CommandParameter.ToString());
        var res= await DisplayAlert("Silmeyi olayna",$"'{ekle.Sinav}' silsin mi?","Evet","Hayir");
        if (res)
            contacts.Remove(ekle);
    }

    String filename = Path.Combine(FileSystem.Current.AppDataDirectory,"data.json");

    private void SaveComanda_Clicked(object sender, EventArgs e)
    {
       
        String data = JsonSerializer.Serialize(contacts);
        File.WriteAllText(filename, data);

      


    }

   
}

public class Contact : INotifyPropertyChanged
{
   
    public string ID
    {
        get
        {

            if (id == null)
               id= Guid.NewGuid().ToString();
            return id;
        }

        set { id = value; }

    }
    String id, vze, fnal ;
    public string Vize { get => vze; set { fnal = value; NotifyPropertyChanged(); NotifyPropertyChanged("Sinav"); } }
    public string Final { get => fnal; set { vze = value; NotifyPropertyChanged(); NotifyPropertyChanged("Sinav"); } }
    public String Sinav=> Vize + "" + Final;
   

    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged([CallerMemberName] string propertyName="")

    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}