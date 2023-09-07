using DAL;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class RepresentationRepository
    {
        public RepresentationRepository(){}

        public async Task<List<Representation>> Load(string path, DesiredPriority desiredPriority, FileLoadingType loadingType)
        {
            string pathLocalOrUrl = loadingType == FileLoadingType.JSON ?
                (path + Representation.SetPath(desiredPriority, loadingType)) :
                (Representation.SetPath(desiredPriority, loadingType));
            List<Representation> reps = await Utils.Utils.Load<Representation>(pathLocalOrUrl, loadingType);
            return reps;
        }

    }
}
