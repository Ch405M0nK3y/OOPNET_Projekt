using DAL;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class RepresentationRepository : IRepo
    {
        public RepresentationRepository(){}

        private List<Representation> representations = new();
        public async Task Load(string path, DesiredPriority desiredPriority, FileLoadingType loadingType, string FavoriteRepFifaCode)
        {
            string pathLocalOrUrl = loadingType == FileLoadingType.JSON ?
                (path + Utils.Utils.SetPath(desiredPriority, loadingType, "results")) :
                (Utils.Utils.SetPath(desiredPriority, loadingType, "results"));
            representations = await Utils.Utils.Load<Representation>(pathLocalOrUrl, loadingType);
            return;
        }

        public List<Representation> GetRepresentations()=> representations;
        
        public Representation GetRep(string fifacode)=> representations.FirstOrDefault(x => x.FifaCode == fifacode);

    }
}
