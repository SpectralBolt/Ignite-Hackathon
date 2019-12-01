using Consultant.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultant.ViewModels
{
    public class CalendarViewModel
    {
        public ObservableCollection<FilterItem> FilterItemsLeft { get; set; }
        public ObservableCollection<FilterItem> FilterItemsRight { get; set; }

        public CalendarViewModel()
        {
            FilterItemsLeft = new ObservableCollection<FilterItem>
            {
                new FilterItem{ Content= "Vacaciones", Image="\uE905"},
                new FilterItem{ Content= "Maternidad", Image="\uE91E"},
                new FilterItem{ Content= "Capacitación", Image="\uE80C"},
                new FilterItem{ Content= "Fechas Especiales", Image="\uE8F6"},
                new FilterItem{ Content= "Pagos Impuestos", Image="\uE263"},
                new FilterItem{ Content= "Altos Picos de Usuario", Image="\uE7F0"},

            };
            FilterItemsLeft = new ObservableCollection<FilterItem>
            {
                new FilterItem { Content = "Interventoria", Image = "\uE90E" },
                new FilterItem { Content = "Reunión General", Image = "\uE91F" },
                new FilterItem{ Content= "Licencia Maternidad", Image="\uEB42"},
                new FilterItem{ Content= "Incapacidad", Image="\uE145"},
                new FilterItem{ Content= "Potencial Visita Cliente", Image="\uE80C"},
                new FilterItem{ Content= "Nominas y Pensiones", Image="\uE614"},
                

            };
            
        }

        public void UpdateValue(int index, bool isLeft)
        {
            var state = false;
            if (isLeft)
            {
                state = FilterItemsLeft.ElementAt(index).State;
                FilterItemsLeft.ElementAt(index).State = !state;
            }
            else
            {
                state = FilterItemsRight.ElementAt(index).State;
                FilterItemsRight.ElementAt(index).State = !state;
            }
        }
    }
}
