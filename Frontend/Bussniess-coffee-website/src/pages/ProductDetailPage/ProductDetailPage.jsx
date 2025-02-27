import React, { useState } from "react";
import "./ProductDetailPage.scss";
import { useParams } from "react-router-dom";
import { Avatar, Rate } from "antd";
import { CoffeeCard } from "@/components/CoffeeCard/CoffeeCard";

function ProductDetailPage() {
  const filterList = [
    {
      key: 1,
      label: "TRUYỀN THỐNG",
    },
    {
      key: 2,
      label: "NHẸ NHÀNG & THANH LỊCH",
    },
    {
      key: 3,
      label: "CÂN BẰNG & HÀI HÒA",
    },
    {
      key: 4,
      label: "ĐẬM ĐÀ & MẠNH MẼ",
    },
    {
      key: 5,
      label: "NHỌT NGÀO & BÉO MỊN",
    },
    {
      key: 6,
      label: "THƯ GIÃN & NGỌT NGÀO",
    },
    {
      key: 7,
      label: "KÍCH THÍCH NĂNG LƯỢNG",
    },
  ];
  const options = [100, 250, 500];
  const [selected, setSelected] = useState(100);

  const { productID } = useParams();
  return (
    <div className="mt-[82px] pp-container">
      <div className="pp-div">
        <div className="pp-wrapper filter-wrapper">
          <h3>TẤT CẢ</h3>
          {filterList.map((item) => (
            <p className="filter-item" key={item.key}>
              {item.label}
            </p>
          ))}
        </div>
        <div className="pp-wrapper pdp-wrapper">
          <h3 className="pdp-title">THANH LỊCH & NHẸ NHÀNG</h3>
          <div className="pdp-product-item">
            <div className="pdp-item">
              <div className="pi-img">
                <img
                  src="https://s3-alpha-sig.figma.com/img/f6dc/ee05/9a80ca85c2cec51003b507e6a3084357?Expires=1740960000&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=f5RTTb~kFxs23qUkdHI3HsSDO1tFoJxrtebFDYPWutSaG1ZEa~Bj0lB5Vqhy5qukBlDahmjOKr-GDAOSTCIbNVE2UWPxLZEhsI8FVZs4wPqhcE~09XqrtpZX4Yi8NI~nrAGTBgGL-6W0b4I8m0QMKkv1NNgFi8xCBKtk5XgOvgh2AdgEKGvAbJ~k4LBn4voqDHkNIiYzg~JlmKpjuR2~I-tSBTM0IBRB6BIrTWiulZ-Q4IhJaCAlB-elIPcdq0wtqs8g9s1aEtqq0Bm~oiDhNk8xJFVQSGB18~nCRKQPyZo~XfsyngV~bE0sktpJgDnjUTqwc5mBD6EYi0CGpgXrAA__"
                  alt="coffee img"
                />
              </div>
              <div className="pi-div">
                <h1>ĐẬM HƯƠNG CHOCO - RUTTY</h1>
                <h2>00,000Đ</h2>
                <div className="items">
                  <h5>ĐỊNH LƯỢNG</h5>
                  <div className="flex gap-3">
                    {options.map((option, index) => (
                      <button
                        key={index}
                        className={`px-4 py-2 rounded-[5px] border border-black transition-all duration-300
                                ${
                                  selected === option
                                    ? "bg-[#ba0000] border  border-[#ba0000] text-white"
                                    : ""
                                }
                            `}
                        onClick={() => setSelected(option)}
                      >
                        {option}g
                      </button>
                    ))}
                  </div>
                </div>
                <div className="items mt-3">
                  <h5>SỐ LƯỢNG</h5>
                  <div className="item">
                    <button>-</button>
                    <p>1</p>
                    <button>+</button>
                  </div>
                </div>
                <a href="">Bạn có muốn custom bao bì?</a>
                <button className="btn-add-to-cart">THÊM VÀO GIỎ HÀNG</button>
              </div>
            </div>

            <h2 className="pdp-h2">Mô tả sản phẩm</h2>
            <div className="pi-script">
              <p>
                <strong>Vùng trồng:</strong> Lâm Đồng
                <br />
                <strong>Sơ chế:</strong> Natural - Honey - Wet Hulled
                <br />
                <strong>Độ rang:</strong> Đậm (Dark Roast)
                <br />
                <strong>Kiểu pha thích hợp:</strong> Espresso, Moka pot, Phin
                giấy, Phin VN
                <br />
                <strong>HẠT CAFE CONTINENTAL CHERRY</strong> là phiên bản hạt
                Cafe Arabica, với những hạt cafe Arabica chín mọng như quả
                Cherry, mang hương thơm hoa quả nhiệt đới và vị ngọt sâu.
                <br />
                Dòng hạt cafe này được rang đậm và hòa trộn từ 3 loại hạt sơ chế
                khác nhau: - Lâm Đồng được sơ chế **Natural, Honey, Wet Hulled
                (Semi Washed)** để bộc lộ hương vị đặc trưng của dòng hạt như:
                **Cherry, Chanh vàng, Socola**.
                <br />
                Hạt cafe Continental Cherry ngon nhất khi uống nguyên bản hoặc
                dùng với sữa đặc.
                <br />
                Rất thích hợp với các kiểu pha: **Máy Espresso, Bình Moka, Phin
                Giấy hoặc Phin Việt Nam**.
                <br />
                <strong>Hạn sử dụng:</strong> 12 tháng kể từ ngày rang.
                <br />
                <strong>Khuyến khích:</strong> khách hàng sử dụng hết trong vòng
                1 tháng kể từ ngày xay.
              </p>
            </div>
            
            <h2 className="pdp-h2">Đánh giá của khách hàng</h2>
            <div className="pdp-review-list">
            <ReviewCard/>
            <ReviewCard/>
            <ReviewCard/>
            </div>

            <h2 className="pdp-h2">Sản phẩm liên quan</h2>
            <div className="pdp-coffee-ls">
              <CoffeeCard/>
              <CoffeeCard/>
              <CoffeeCard/>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

const ReviewCard = ()=>{
  // const urlImg = 'https://image-2.uhdpaper.com/wallpaper/anime-girl-flower-4k-wallpaper-uhdpaper.com-732@2@b.jpg';
  return(
    <div className="review-container">
      <img src='https://laban.edu.vn/wp-content/uploads/2024/02/11.2_Emma_Watson-768x960.jpg?x87650'
      className="avatar-img"/>
      <div className="review-info">
        <p>Stella Melanie</p>
        <Rate allowHalf disabled defaultValue={4.5} style={{fontSize:13}}/>
        <p>10/22/2024  9:30</p>
        <p>Cafe thật sự rất thơm, bao bì rất đẹp. Sẽ quay lại nhiều lần</p>
      </div>
    </div>
  )
}

export default ProductDetailPage;
