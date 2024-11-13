namespace MyProject;

public partial class EklePage : ContentPage
{
	public EklePage()
	{
		InitializeComponent();
	}
    protected override void OnParentSet()
    {
        base.OnParentSet();
        if(Ekle!=null)
        {
              txtEkle.Text = Ekle.Final;
              //txtEkle.Text = Ekle.Vize;
            
        }
    }
    public bool Result { get; set; } = false;

    public Contact Ekle { get; set; }
    public Action<Contact> AddMethod { get; internal set; }

    private void btnOk_Clicked(object sender, EventArgs e)
    {
        if (Ekle == null)
        {
            Ekle = new Contact()
            {
               // Vize = txtEkle.Text,
                Final = txtEkle.Text,
            };
        }
        else
        {
          //  Ekle.Vize = txtEkle.Text;
            Ekle.Final = txtEkle.Text;
        } if (AddMethod != null)
        {
            AddMethod(Ekle);
        }

        Result = true;
        Navigation.PopAsync();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Result = false;
        Navigation.PopAsync();
    }
}