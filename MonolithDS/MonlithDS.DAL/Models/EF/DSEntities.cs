namespace MonlithDS.DAL.Models
{
    using System.Data.Entity;

    // ReSharper disable once InconsistentNaming
    public partial class DSEntities : DbContext
    {
        public DSEntities()
            : base("name=DSEntities")
        {
            Database.SetInitializer<DSEntities>(new CreateDatabaseIfNotExists<DSEntities>());
        }

        public virtual DbSet<AccessProfile> AccessProfile { get; set; }
        public virtual DbSet<AmazonAccount> AmazonAccount { get; set; }
        public virtual DbSet<AmazonItem> AmazonItem { get; set; }
        public virtual DbSet<AmazonItemFeatures> AmazonItemFeatures { get; set; }
        public virtual DbSet<AmazonItemImages> AmazonItemImages { get; set; }
        public virtual DbSet<AmazonItemSearch> AmazonItemSearch { get; set; }
        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<EbayAccount> EbayAccount { get; set; }
        public virtual DbSet<EbayAccountFeeDates> EbayAccountFeeDates { get; set; }
        public virtual DbSet<EbayAPI> EbayAPI { get; set; }
        public virtual DbSet<EbayCategories> EbayCategories { get; set; }
        public virtual DbSet<EbayFeedback> EbayFeedback { get; set; }
        public virtual DbSet<EbayListing> EbayListing { get; set; }
        public virtual DbSet<EbayListingCondition> EbayListingCondition { get; set; }
        public virtual DbSet<EbayListingDuration> EbayListingDuration { get; set; }
        public virtual DbSet<EbayListingErrors> EbayListingErrors { get; set; }
        public virtual DbSet<EbayListingFeatures> EbayListingFeatures { get; set; }
        public virtual DbSet<EbayListingImages> EbayListingImages { get; set; }
        public virtual DbSet<EbayOrderChanges> EbayOrderChanges { get; set; }
        public virtual DbSet<EbayOrders> EbayOrders { get; set; }
        public virtual DbSet<EbayReturnPolicy> EbayReturnPolicy { get; set; }
        public virtual DbSet<EbayShipping> EbayShipping { get; set; }
        public virtual DbSet<EbayTaxes> EbayTaxes { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EventLog> EventLog { get; set; }
        public virtual DbSet<FeeCalculationValues> FeeCalculationValues { get; set; }
        public virtual DbSet<ListingFees> ListingFees { get; set; }
        public virtual DbSet<PayPal> PayPal { get; set; }
        public virtual DbSet<PriceRanges> PriceRanges { get; set; }
        public virtual DbSet<ProductRestrictions> ProductRestrictions { get; set; }
        public virtual DbSet<ServiceSettings> ServiceSettings { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmazonItem>()
                .HasMany(e => e.AmazonItemFeatures)
                .WithRequired(e => e.AmazonItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AmazonItem>()
                .HasMany(e => e.AmazonItemImages)
                .WithRequired(e => e.AmazonItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Card>()
                .HasMany(e => e.AmazonAccount)
                .WithRequired(e => e.Card)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EbayAccount>()
                .HasMany(e => e.EbayAccountFeeDates)
                .WithRequired(e => e.EbayAccount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EbayCategories>()
                .HasMany(e => e.EbayListing)
                .WithRequired(e => e.EbayCategories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EbayFeedback>()
                .HasMany(e => e.EbayListing)
                .WithOptional(e => e.EbayFeedback)
                .HasForeignKey(e => e.DescriptionFeedback);

            modelBuilder.Entity<EbayListing>()
                .HasMany(e => e.EbayListingErrors)
                .WithRequired(e => e.EbayListing)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EbayListing>()
                .HasMany(e => e.EbayListingFeatures)
                .WithRequired(e => e.EbayListing)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EbayListing>()
                .HasMany(e => e.EbayListingImages)
                .WithRequired(e => e.EbayListing)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EbayListing>()
                .HasMany(e => e.ListingFees)
                .WithRequired(e => e.EbayListing)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EbayListingCondition>()
                .HasMany(e => e.EbayListing)
                .WithRequired(e => e.EbayListingCondition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EbayListingDuration>()
                .HasMany(e => e.EbayListing)
                .WithOptional(e => e.EbayListingDuration)
                .HasForeignKey(e => e.ListingDurationID);

            modelBuilder.Entity<EbayOrders>()
                .HasMany(e => e.EbayOrderChanges)
                .WithRequired(e => e.EbayOrders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EbayReturnPolicy>()
                .HasMany(e => e.EbayListing)
                .WithOptional(e => e.EbayReturnPolicy)
                .HasForeignKey(e => e.DescriptionReturnPolicy);

            modelBuilder.Entity<EbayShipping>()
                .HasMany(e => e.EbayListing)
                .WithOptional(e => e.EbayShipping)
                .HasForeignKey(e => e.DescriptionShipping);

            modelBuilder.Entity<EbayTaxes>()
                .HasMany(e => e.EbayListing)
                .WithOptional(e => e.EbayTaxes)
                .HasForeignKey(e => e.DescriptionTaxes);
        }
    }
}
