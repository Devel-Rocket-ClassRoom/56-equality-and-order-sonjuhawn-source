using System;
using System.Collections.Generic;

// README.md를 읽고 코드를 작성하세요.
Console.WriteLine();

List<AuctionItem> auction = new List<AuctionItem>
{
    new AuctionItem{ Name = "전설의 검", Category = "무기", CurrentBid = 50000, BidCount = 12  },
    new AuctionItem{ Name = "미스릴 갑옷", Category = "방어구", CurrentBid = 35000, BidCount = 8  },
    new AuctionItem{ Name = "불꽃 반지", Category = "장신구", CurrentBid = 28000, BidCount = 15  },
    new AuctionItem{ Name = "만능 물약", Category = "소비", CurrentBid = 5000, BidCount = 20  },
    new AuctionItem{ Name = "회복 물약", Category = "소비", CurrentBid = 5000, BidCount = 3  }
};


class AuctionItem
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int CurrentBid { get; set; }
    public int BidCount { get; set; }

    public override string ToString()
    {
        return $"{Name} [{Category}] - 입찰가: {CurrentBid}골드 (입찰 {BidCount}회)";
    }
}

class BidComparer : Comparer<AuctionItem>
{
    public override int Compare(AuctionItem x, AuctionItem y)
    {
        if (x.CurrentBid == 0 && y.CurrentBid == 0)
        {
            return 0;
        }
        if(x.CurrentBid == 0)
        {
            return -1;
        }
        if(y.CurrentBid == 0)
        {
            return 1;
        }
        int result = y.CurrentBid.CompareTo(x.CurrentBid);
        if(result != 0)
        {
            return result;
        }
        return x.Name.CompareTo(y.Name);
    }
}