using MediatR;
using QRCoder;

namespace GoldenHour.Application.Users
{
    public class GenerateQRCode
    {
        public class Query : IRequest<byte[]>
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, byte[]>
        {
            public Task<byte[]> Handle(Query request, CancellationToken cancellationToken)
            {
                using (var qrGenerator = new QRCodeGenerator())
                {
                    var qrCodeData = qrGenerator.CreateQrCode($"{request.UserId}|{request.UserName}", 
                        QRCodeGenerator.ECCLevel.Q);
                    var qrCode = new BitmapByteQRCode(qrCodeData);

                    var qrCodeBitmap = qrCode.GetGraphic(20);
                    return Task.FromResult(qrCodeBitmap);
                }
            }
        }
    }
}
