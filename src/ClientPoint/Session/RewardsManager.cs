using System.Collections.Generic;
using System.Linq;

namespace ClientPoint.Session {
    public class RewardsManager {
        public List<Reward> Rewards;
        public Dictionary<int, string> Categories;

        public RewardsManager(List<Reward> rewards) {
            Rewards = rewards;
            //Rewards.AddRange(rewards);
            //Rewards.AddRange(rewards);
            LoadCategories();
        }

        private void LoadCategories() {
            Categories = new Dictionary<int, string>();
            Rewards.ForEach(r => {
                if (Categories.ContainsKey(r.IdCategory))
                    return;
                Categories.Add(r.IdCategory, r.CategoryName);
            });
        }

        public List<Reward> GetByCategory(int id) {
            var res = new List<Reward>();
            foreach (var r in Rewards) {
                if(r.IdCategory == id)
                    res.Add(r);
            }
            return res;
        }
    }
}
