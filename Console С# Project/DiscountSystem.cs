using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore
{
    public interface IDiscount
    {
        string Name {
            get;
        }
        decimal Calculate(decimal amount);
        bool IsApplicable(decimal amount);
    }

    public abstract class Discount : IDiscount
    {
        public abstract string Name { 
            get;
        }
        public decimal MinimumAmount {
            get;
            protected set; 
        }

        protected Discount(decimal minimumAmount)
        {
            MinimumAmount = minimumAmount;
        }
        public abstract decimal Calculate(decimal amount);

        public virtual bool IsApplicable(decimal amount)
        {
            return amount >= MinimumAmount;
        }

        public override string ToString()
        {
            return 
                $"{Name} (Мінімум: {MinimumAmount:C0} грн)";
        }
    }

    [Serializable]

    public class PercentageDiscount : Discount
    {
        public decimal Percentage {
            get; 
            private set; 
        }

        public override string Name => $"Знижка {Percentage}%";

        public PercentageDiscount(decimal percentage, decimal minimumAmount) : base(minimumAmount)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentException("Відсоток знижки має бути між 0 і 100");

            Percentage = percentage;
        }

        public override decimal Calculate(decimal amount)
        {
            if (!IsApplicable(amount))
                return 0;

            return amount * (Percentage / 100);
        }
    }

    [Serializable]
    public class FixedDiscount : Discount
    {
        public decimal DiscountAmount {
            get;
            private set;
        }

        public override string Name => $"Знижка {DiscountAmount:C0} грн";

        public FixedDiscount(decimal discountAmount, decimal minimumAmount) : base(minimumAmount)
        {
            if (discountAmount < 0)
                throw new ArgumentException("Сума знижки не може бути від'ємною");

            DiscountAmount = discountAmount;
        }

        public override decimal Calculate(decimal amount)
        {
            if (!IsApplicable(amount))
                return 0;

            return 
                Math.Min(DiscountAmount, amount);
        }
    }

    [Serializable]
    public class PromoCodeDiscount : Discount
    {
        public string Code {
            get; 
            private set;
        }
        public decimal Percentage { 
            get;
            private set; 
        }
        public DateTime ExpirationDate { 
            get; 
            private set;
        }

        public override string Name => $"Промо-код {Code}";

        public PromoCodeDiscount(string code, decimal percentage, decimal minimumAmount, DateTime expirationDate) : base(minimumAmount)
        {
            Code = code?.ToUpper() ?? throw new ArgumentNullException(nameof(code));
            Percentage = percentage;
            ExpirationDate = expirationDate;
        }

        public override decimal Calculate(decimal amount)
        {
            if (!IsApplicable(amount))
                return 0;

            return amount * (Percentage / 100);
        }

        public override bool IsApplicable(decimal amount)
        {
            return base.IsApplicable(amount) && DateTime.Now <= ExpirationDate;
        }
    }

    public class DiscountManager
    {
        private readonly List<IDiscount> discounts;

        public delegate decimal DiscountCalculator(decimal amount);

        public event EventHandler<DiscountAppliedEventArgs> DiscountApplied;

        public DiscountManager()
        {
            discounts = new List<IDiscount>();
        }

        public void AddDiscount(IDiscount discount)
        {
            if (discount == null)
                throw new ArgumentNullException(nameof(discount));

            discounts.Add(discount);
        }

        public decimal CalculateDiscount(decimal amount)
        {
            if (amount <= 0 || !discounts.Any())
                return 0;

            var bestDiscount = discounts.Where(d => d.IsApplicable(amount)).Select(d => new { Discount = d, Amount = d.Calculate(amount) }).OrderByDescending(x => x.Amount).FirstOrDefault();

            if (bestDiscount != null && bestDiscount.Amount > 0)
            {
                OnDiscountApplied(new DiscountAppliedEventArgs(bestDiscount.Discount.Name,bestDiscount.Amount));
                return bestDiscount.Amount;
            }

            return 0;
        }
        public IEnumerable<IDiscount> GetApplicableDiscounts(decimal amount)
        {
            return discounts.Where(d => d.IsApplicable(amount));
        }

        public bool ApplyPromoCode(string code, decimal amount, out decimal discountAmount)
        {
            discountAmount = 0;

            var promo = discounts.OfType<PromoCodeDiscount>().FirstOrDefault(p => p.Code == code?.ToUpper());

            if (promo != null && promo.IsApplicable(amount))
            {
                discountAmount = promo.Calculate(amount);
                return true;
            }
            return false;
        }

        public void ClearDiscounts()
        {
            discounts.Clear();
        }

        protected virtual void OnDiscountApplied(DiscountAppliedEventArgs e)
        {
            DiscountApplied?.Invoke(this, e);
        }

        public IDiscount CreateCustomDiscount(string name, Func<decimal, decimal> calculator, decimal minimumAmount)
        {
            return new CustomDiscount(name, calculator, minimumAmount);
        }
    }

    public class CustomDiscount : Discount
    {
        private readonly Func<decimal, decimal> calculator;

        public override string Name {
            get; 
        }

        public CustomDiscount(string name, Func<decimal, decimal> calculator, decimal minimumAmount) : base(minimumAmount)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public override decimal Calculate(decimal amount)
        {
            if (!IsApplicable(amount))
                return 0;

            return calculator(amount);
        }
    }

    public class DiscountAppliedEventArgs : EventArgs
    {
        public string DiscountName {
            get; 
            set;
        }
        public decimal DiscountAmount { 
            get;
            set; 
        }
        public DateTime AppliedAt {
            get;
            set;
        }

        public DiscountAppliedEventArgs(string discountName, decimal discountAmount)
        {
            DiscountName = discountName;
            DiscountAmount = discountAmount;
            AppliedAt = DateTime.Now;
        }
    }
    public class CompositeDiscount : Discount
    {
        private readonly List<IDiscount> discounts;

        public override string Name => "Комбінована знижка";

        public CompositeDiscount(decimal minimumAmount) : base(minimumAmount)
        {
            discounts = new List<IDiscount>();
        }

        public void AddDiscount(IDiscount discount)
        {
            discounts.Add(discount);
        }

        public override decimal Calculate(decimal amount)
        {
            if (!IsApplicable(amount))
                return 0;

            return discounts.Where(d => d.IsApplicable(amount)).Sum(d => d.Calculate(amount));
        }
    }
}