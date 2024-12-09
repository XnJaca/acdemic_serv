
using FluentValidation;
using infrastructure.Entities;

namespace infrastructure.Utils;

public class PagingData {
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

    public IQueryable<T> Paginate<T> ( IQueryable<T> queryable ) where T : BaseEntity {
        var size = PageSize ?? 20;
        if ( AtFirstPage ?? false ) {
            return queryable.OrderBy(e => e.Id)
                .Take(size);
        } else if ( AtLastPage ?? false ) {
            return queryable.OrderByDescending(e => e.Id)
                .Take(size)
                .OrderBy(e => e.Id);
        }

        var key = PageKey ?? 0;
        return queryable.OrderBy(e => e.Id)
            .Where(e => e.Id > key)
            .Take(size);
    }

    public class PagingDataValidator: AbstractValidator<PagingData> {
        public PagingDataValidator ( ) {
            When(p => p.PageSize is not null, ( ) => {
                RuleFor(p => p.PageSize).InclusiveBetween(1, 250);
            });
        }
    }
}