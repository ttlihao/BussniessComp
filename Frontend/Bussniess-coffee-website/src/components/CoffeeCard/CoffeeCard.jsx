import { useNavigate } from "react-router-dom";

export const CoffeeCard = () => {
    const navigate = useNavigate();
    const handleProductDetail = () => navigate(`/products/1`);
    return (
      <div className="coffee-card-container" onClick={handleProductDetail}>
        <img src="https://s3-alpha-sig.figma.com/img/f6dc/ee05/9a80ca85c2cec51003b507e6a3084357?Expires=1741564800&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=RDoJglXG3BxXZYodVrSkfGpjvrBmtCauvUdKlAn~ddHSdtZMV5xb-bAg3uFCJvEXNxeQROdGKgkDeZhLgRRD3662Q9c1oTlyn9HNohsKk8IvLQ2XXqSvNJfHsx98MlyrZdPvGyONDF26RMkzR~rwLxNo1T147NnkHovGl6kG~pPBq9dgEX2ARnspljpcqjgmZcmIylvLWNIJBFPCiqpz1TaDEcFxqUHb2E4k24xXCcEB5oFX3hGvw~ke8jmpquvBnZE83LO-bVg54tt4edA4GzF1Io~1UAxhJkF4m5XcigGKVP1O5~2KaVyrahSbzVCSCekXQeM~fDqseJAKinah7Q__" alt="coffee img" />
        <h2>Đậm hương CHOCO - RUTTY</h2>
        {/* <p>80% ARABICA - 20% ROBUSTA</p> */}
        <h3>Từ 200,000Đ</h3>
      </div>
    );
  };