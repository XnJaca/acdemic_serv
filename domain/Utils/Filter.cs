using infrastructure.Utils;

namespace domain.Utils {
    public class Filter {
        public int? PageSize {
            get; set;
        }
        public int? PageKey {
            get; set;
        }
        public bool? AtFirstPage {
            get; set;
        }
        public bool? AtLastPage {
            get; set;
        }

        public PagingData ToPaginData ( ) {
            return new PagingData {
                PageSize =  PageSize,
                PageKey = PageKey,
                AtFirstPage = AtFirstPage,
                AtLastPage = AtLastPage
            };
        }
    }
}
