using GymManagment.Models;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
namespace GymManagment.Repository
{
    public class SubscriptionRepository
    {
        private readonly GymContext _context;
        public SubscriptionRepository(GymContext context)
        {
            _context = context;
        }
        public void CreateSubscription(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            _context.SaveChanges();
        }
        public List<Subscription> GetAllSubscriptions()
        {
            return _context.Subscriptions.ToList();
        }
        public  Subscription GetSubscriptionBy(string Code, string description, int numberOfMonths, string weekfrequency)
        {
            return _context.Subscriptions.FirstOrDefault
           (s =>
        s.Code == Code &&
        s.Description == description &&
        s.NumberOfMonths == numberOfMonths &&
        s.WeekFrequency == weekfrequency);
        }
        public Subscription UpdateSubscription(Subscription subscription)
        {
            if (subscription == null)
            {
                throw new ArgumentNullException("Subscription can not be null");
            }
            var existingSubscription = _context.Subscriptions.FirstOrDefault(sub => sub.Id == subscription.Id);
            if (existingSubscription == null)
            {
                throw new ArgumentNullException("Subscription was not found");
            }
            existingSubscription.Description = subscription.Description;
            existingSubscription.NumberOfMonths = subscription.NumberOfMonths;
            existingSubscription.WeekFrequency = subscription.WeekFrequency;
            existingSubscription.TotalNumberOfSessions = subscription.TotalNumberOfSessions;
            existingSubscription.TotalPrice = subscription.TotalPrice;
            _context.SaveChanges();
            return existingSubscription;
        }
        public void SoftDelete(int Id)
        {
            var subscription = _context.Subscriptions.Where(i=> i.IsDeleted == false && i.Id == Id).FirstOrDefault();
            if (subscription == null)
            {
                throw new ArgumentException("Subscription not found.");
            }
            subscription.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}