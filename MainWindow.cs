﻿using DB_993;

namespace design
{
    public partial class MainWindow : Form
    {
        string Email { get; set; }
        int I { get; set; }
        Dictionary<int, decimal> DictRecom { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Disign();
        }
        public MainWindow(GetRecommendation getRecommendation)
        {
            InitializeComponent();
            Disign();
            FullListRecommendation(getRecommendation);
            FillRecommendation();
        }
        public MainWindow(string email)
        {
            InitializeComponent();
            Disign();
            Email = email;
        }
        public void FullListRecommendation(GetRecommendation getRecommendation)
        {
            Dictionary<int, decimal> dictRecom = new Dictionary<int, decimal>();
            using (var context = new ApplicationContex())
            {
                var existingRealty = context.Realtys.ToList();
                for (int i = 0; i < existingRealty.Count; i++)
                {
                    dictRecom.Add(existingRealty[i].Id, CalculateOverallRating(getRecommendation, existingRealty[i]));
                }
                DictRecom = dictRecom;

            }

        }
        public void FillRecommendation()
        {
            if (I < 0 && I > DictRecom.Count)
            {
                return;
            }
            var sortDict = from pair in DictRecom orderby pair.Value descending select pair;
            List<int> sortList = new List<int>();
            foreach (var pair in sortDict)
            {
                sortList.Add(pair.Key);
            }
            using (var context = new ApplicationContex())
            {

                var existingRealty = context.Realtys.FirstOrDefault(realty => realty.Id == sortList[I]);
                RealtyPhoto.Image = Image.FromFile(existingRealty!.PhotoRealty!.ToString());
                AddressText.Text = existingRealty.Address;
                PriceText.Text = existingRealty.Price.ToString();
                FloorText.Text = existingRealty.Floor.ToString();
                SquareText.Text = existingRealty.Square.ToString();
            }
        }
        public decimal CalculateOverallRating(GetRecommendation getRecommendation, Realty existingRealty)
        {

            decimal comparisonPrice = getRecommendation.RatingPrice < existingRealty.Price ? (existingRealty.Price / getRecommendation.RatingPrice) : (getRecommendation.RatingPrice / existingRealty.Price);
            decimal comparisonFloor = getRecommendation.RatingFloоr < existingRealty.Floor ? (existingRealty.Floor / getRecommendation.RatingFloоr) : (getRecommendation.RatingFloоr / existingRealty.Floor);
            decimal comparisonSquare = getRecommendation.RatingSquare < existingRealty.Square ? (existingRealty.Square / getRecommendation.RatingPrice) : (getRecommendation.RatingSquare / existingRealty.Square);
            decimal comparisonRooms = getRecommendation.RatingRooms < existingRealty.Rooms ? (existingRealty.Rooms / getRecommendation.RatingRooms) : (getRecommendation.RatingRooms / existingRealty.Rooms);
            int comparisonCity = getRecommendation.RatingCity == existingRealty.City ? (1) : (0);
            int comparisonType = getRecommendation.RatingType == existingRealty.Type ? (1) : (0);
            int comparisonForWgat = getRecommendation.RatingForWhat == existingRealty.ForWhat ? (1) : (0);

            decimal overallRating = (comparisonPrice + comparisonFloor + comparisonSquare + comparisonRooms + comparisonCity + comparisonType + comparisonForWgat) / 7;
            return overallRating;
        }
        public void Disign()
        {
            label1.Parent = Picture3;
            label1.BackColor = Color.Transparent;
            Address.Parent = Picture3;
            Address.BackColor = Color.Transparent;
            Price.Parent = Picture3;
            Price.BackColor = Color.Transparent;
            Square.Parent = Picture3;
            Square.BackColor = Color.Transparent;
            AmountOfFloors.Parent = Picture3;
            AmountOfFloors.BackColor = Color.Transparent;
            Floor.Parent = Picture3;
            Floor.BackColor = Color.Transparent;
            ProfileButton.Parent = Picture3;
            ProfileButton.BackColor = Color.Transparent;
            ProfileButton.FlatAppearance.BorderSize = 0;
            ProfileButton.FlatStyle = FlatStyle.Flat;
            FavButton.Parent = Picture3;
            FavButton.BackColor = Color.Transparent;
            FavButton.FlatAppearance.BorderSize = 0;
            FavButton.FlatStyle = FlatStyle.Flat;
            BlackListButton.Parent = Picture3;
            BlackListButton.BackColor = Color.Transparent;
            BlackListButton.FlatAppearance.BorderSize = 0;
            BlackListButton.FlatStyle = FlatStyle.Flat;
            MyListsButton.Parent = Picture3;
            MyListsButton.BackColor = Color.Transparent;
            MyListsButton.FlatAppearance.BorderSize = 0;
            MyListsButton.FlatStyle = FlatStyle.Flat;
            BackButton.Parent = Picture3;
            BackButton.BackColor = Color.Transparent;
            BackButton.FlatAppearance.BorderSize = 0;
            BackButton.FlatStyle = FlatStyle.Flat;
            StraightButton.Parent = Picture3;
            StraightButton.BackColor = Color.Transparent;
            StraightButton.FlatAppearance.BorderSize = 0;
            StraightButton.FlatStyle = FlatStyle.Flat;
            AddButton.Parent = Picture3;
            AddButton.BackColor = Color.Transparent;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.FlatStyle = FlatStyle.Flat;
            EstimateButton.Parent = Picture3;
            EstimateButton.BackColor = Color.Transparent;
            EstimateButton.FlatAppearance.BorderSize = 0;
            EstimateButton.FlatStyle = FlatStyle.Flat;
            AddressText.Parent = Picture3;
            AddressText.BackColor = Color.Transparent;
            PriceText.Parent = Picture3;
            PriceText.BackColor = Color.Transparent;
            SquareText.Parent = Picture3;
            SquareText.BackColor = Color.Transparent;
            FloorText.Parent = Picture3;
            FloorText.BackColor = Color.Transparent;
            AddFavButton.Parent = Picture3;
            AddFavButton.BackColor = Color.Transparent;
            AddFavButton.FlatAppearance.BorderSize = 0;
            AddFavButton.FlatStyle = FlatStyle.Flat;
            AddBlackListButton.Parent = Picture3;
            AddBlackListButton.BackColor = Color.Transparent;
            AddBlackListButton.FlatAppearance.BorderSize = 0;
            AddBlackListButton.FlatStyle = FlatStyle.Flat;
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(Email);
            profile.ShowDialog();
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddList addList = new AddList();
            addList.ShowDialog();
        }

        private void FormMyRecommendationButton_Click(object sender, EventArgs e)
        {
            TestFirstWindow testFirstWindow = new TestFirstWindow();
            testFirstWindow.ShowDialog();
            this.Close();
        }

        private void FavButton_Click(object sender, EventArgs e)
        {
            Favorite favorite = new Favorite();
            favorite.ShowDialog();
            this.Close();
        }

        private void StraightButton_Click(object sender, EventArgs e)
        {
            if (I++ < DictRecom.Count)
            {
                I++;
                FillRecommendation();
            }

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (I-- > 0)
            {
                I--;
                FillRecommendation();
            }
           
        }
    }
}
