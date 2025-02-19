import React, { useState } from "react";
import "./ProductDetailPage.scss";
import { useParams } from "react-router-dom";

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
  const options = ["Loại 1", "Loại 2", "Loại 3", "Loại 4"];
  const [selected, setSelected] = useState(null);

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
            <div className="pi-img">
              <img
                src="https://s3-alpha-sig.figma.com/img/f6dc/ee05/9a80ca85c2cec51003b507e6a3084357?Expires=1740960000&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=f5RTTb~kFxs23qUkdHI3HsSDO1tFoJxrtebFDYPWutSaG1ZEa~Bj0lB5Vqhy5qukBlDahmjOKr-GDAOSTCIbNVE2UWPxLZEhsI8FVZs4wPqhcE~09XqrtpZX4Yi8NI~nrAGTBgGL-6W0b4I8m0QMKkv1NNgFi8xCBKtk5XgOvgh2AdgEKGvAbJ~k4LBn4voqDHkNIiYzg~JlmKpjuR2~I-tSBTM0IBRB6BIrTWiulZ-Q4IhJaCAlB-elIPcdq0wtqs8g9s1aEtqq0Bm~oiDhNk8xJFVQSGB18~nCRKQPyZo~XfsyngV~bE0sktpJgDnjUTqwc5mBD6EYi0CGpgXrAA__"
                alt=""
              />
            </div>
            <div className="pi-div">
              <h1>ĐẬM HƯƠNG CHOCO - RUTTY</h1>
              <h2>00,000Đ</h2>
              <h5>ĐỊNH LƯỢNG</h5>
              <div className="flex gap-3">
                {options.map((option, index) => (
                  <button
                    key={index}
                    className={`px-4 py-2 border rounded-lg transition-all duration-300
                            ${
                              selected === option
                                ? "bg-red-500 text-white"
                                : "bg-gray-200"
                            }
                        `}
                    onClick={() => setSelected(option)}
                  >
                    {option}
                  </button>
                ))}
              </div>
              <h5>SỐ LƯỢNG</h5>
              <div>
                <button>-</button>
                <p>1</p>
                <button>+</button>
              </div>
              <button className="btn-add-to-cart">THÊM VÀO GIỎ HÀNG</button>
            </div>

            <h2>Mô tả sản phẩm</h2>
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
            
          </div>
        </div>
      </div>
    </div>
  );
}

export default ProductDetailPage;
