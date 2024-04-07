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
        private Subscription GetSubscriptionBy(int Code, string description, int numberOfMonths, int weekfrequency)
        {
            return _context.Subscriptions.Find(Code, description, numberOfMonths, weekfrequency);
        }
        public void UpdateSubscription(Subscription subscription)
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
            existingSubscription.NumberOfMonths = subscription.NumberOfMonths;
            existingSubscription.WeekFrequency = subscription.WeekFrequency;
            existingSubscription.TotalNumberOfSessions = subscription.TotalNumberOfSessions;
            existingSubscription.TotalPrice = subscription.TotalPrice;
            _context.SaveChanges();
        }
        public void SoftDelete(int Id)
        {
            var subscription = _context.Subscriptions.FirstOrDefault(sub => sub.Id == Id);
            if (subscription != null)
            {
                throw new ArgumentException("Subscription not found.");
            }
            subscription.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}