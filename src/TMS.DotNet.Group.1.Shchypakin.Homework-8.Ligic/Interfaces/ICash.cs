namespace TMS.DotNet.Group._1.Shchypakin.Homework_8.Ligic.Interfaces
{
    public interface ICash
    {
        /// <summary>
        /// Cash ID
        /// </summary>
        public int CashIndex { get; set; }

        /// <summary>
        /// Time that takes an ICash to perform method GetMoney (time delay)
        /// </summary>
        public int CasherDelayTime { get; set; }

        /// <summary>
        /// Working status
        /// </summary>
        public bool IsWorking { get; set; }

        /// <summary>
        /// Returns the count of the local Queue
        /// </summary>
        /// <returns></returns>
        public int GetQueueCount();

        /// <summary>
        /// Enqueue an ICustomer in the local Queue
        /// </summary>
        /// <param name="customer"></param>
        public void TakeQueue(ICustomer customer);

        /// <summary>
        /// Cycled work of the ICash (Dequeues customers and shows the balance)
        /// </summary>
        public void GetMoney();
    }
}