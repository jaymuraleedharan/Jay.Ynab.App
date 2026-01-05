using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.UI
{
    public class MainPresenter
    {
        private readonly IMainView _view = null;

        public MainPresenter(IMainView view)
        {
            _view = view;
        }
    }
}
