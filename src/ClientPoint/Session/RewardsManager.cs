using System.Collections.Generic;
using System.Linq;

namespace ClientPoint.Session {
    public class RewardsManager {
        public List<Reward> CurrentRewards;
        public int CurrentCategory;
        public List<Reward> Rewards;
        public Dictionary<int, string> Categories;
        public int TotalPages;
        public int CurrentPage;
        private const int PAGE_SIZE = 8;

        public RewardsManager(List<Reward> rewards) {
            Rewards = rewards;
            LoadCategories();
            CurrentCategory = 0;
            CurrentRewards = Rewards;
            CalcPages();
            Select();
        }

        private void CalcPages() {
            TotalPages = 
                ((CurrentRewards.Count - 1) / PAGE_SIZE) + 1;
            CurrentPage = 1;
        }

        private void Select() {
            var src = CurrentCategory == 0 ? 
                Rewards : GetByCategory(CurrentCategory);
            CurrentRewards = src.Skip(PAGE_SIZE * (CurrentPage - 1)).Take(PAGE_SIZE).ToList();
        }

        private void LoadCategories() {
            Categories = new Dictionary<int, string>();
            Rewards.ForEach(r => {
                if (Categories.ContainsKey(r.IdCategory))
                    return;
                Categories.Add(r.IdCategory, r.CategoryName);
            });
        }

        private List<Reward> GetByCategory(int id) {
            var res = new List<Reward>();
            foreach (var r in Rewards) {
                if(r.IdCategory == id)
                    res.Add(r);
            }
            return res;
        }

        public void Filter(int id) {
            CurrentRewards = id == 0 ? 
                Rewards : GetByCategory(id);
            CurrentCategory = id;
            CalcPages();
            Select();
        }

        public void Next() {
            if (CurrentPage == TotalPages)
                return;
            CurrentPage++;
            Select();
        }

        public void Prev() {
            if (CurrentPage == 1)
                return;
            CurrentPage--;
            Select();
        }

        public bool FirstPage =>
            CurrentPage == 1;

        public bool LastPage => 
            CurrentPage == TotalPages;


    }
}
