using Nop.Plugin.Shipping.EuroQuip.Models;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Checkout
{
    public partial record CheckoutPickupPointsModel : BaseNopModel
    {
        public PickupDetailModel pickUpDetailModel
        {

            get
            {
                if (TempPdModel == null)
                    TempPdModel = new PickupDetailModel();
                return TempPdModel;
            }
            set { TempPdModel = value; }
        }

        public PickupDetailModel TempPdModel;

        public int SelectedPickupPoint { get; set; }
    }
}