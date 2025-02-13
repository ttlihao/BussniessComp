import React, { useState } from "react";
import "./SignInPage.scss";
import { Button, Form, Input, message, Modal } from "antd";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import Cookies from "js-cookie";
import { CheckCircleOutlined } from "@ant-design/icons";
import { RiVerifiedBadgeFill } from "react-icons/ri";

function SignInPage() {
  const navigate = useNavigate();
  const [messageApi, contextHolder] = message.useMessage();
  const [isModalVisible, setIsModalVisible] = useState(false);

  const onFinish = async (values) => {
    try {
      const response = await axios.post(
        "https://localhost:7240/api/authenticate/login",
        values,
        {
          headers: { "Content-Type": "application/json" },
        }
      );

      if (response.data) {
        // Lưu thông tin vào cookie (thời gian hết hạn 30 ngày)
        Cookies.set("userData", JSON.stringify(response.data), { expires: 30 });

        // Hiển thị thông báo thành công
        setIsModalVisible(true);

        setTimeout(() => {
          setIsModalVisible(false);
          navigate("/");
        }, 2000);
      }
    } catch (error) {
      message.error("Đăng nhập thất bại! Vui lòng kiểm tra lại thông tin.");
    }
  };

  return (
    <div className="signin-container mt-[82px]">
      <div className="signin-wrapper">
        <h1>Đăng nhập</h1>
        <p className="font-medium text-lg text-center mb-6 text-white">
          Bạn chưa có tài khoản? &nbsp;
          <a
            href="/sign-up"
            className="underline text-white hover:text-[#ba0000]"
          >
            Đăng Kí
          </a>
        </p>

        <div className="btn-login-with">
          <img src="icons/google.png" alt="google icon" />
          <p>Tiếp tục với Google</p>
        </div>
        <div className="btn-login-with">
          <img src="icons/facebook.png" alt="facebook icon" />
          <p>Tiếp tục với Facebook</p>
        </div>

        <div className="flex items-center my-4">
          <div className="flex-1 border-t border-white"></div>
          <span className="px-4 text-white">Hoặc</span>
          <div className="flex-1 border-t border-white"></div>
        </div>

        <Form name="login" layout="vertical" onFinish={onFinish}>
          <Form.Item
            name="userName"
            className="form-custom"
            rules={[{ required: true, message: "Vui lòng nhập Username!" }]}
          >
            <div>
              <label className="form-label">Username</label>
              <Input placeholder="Enter your Username" className="form-input" />
            </div>
          </Form.Item>

          <Form.Item
            name="password"
            className="form-custom"
            rules={[{ required: true, message: "Vui lòng nhập mật khẩu!" }]}
          >
            <div>
              <label className="form-label">Mật khẩu của bạn</label>
              <Input.Password
                placeholder="Enter your Password"
                className="form-input"
              />
            </div>
          </Form.Item>

          <div className="text-white mb-4">
            <a
              href="/forgot-password"
              className="block text-right underline hover:text-[#ba0000] mt-[-18px]"
            >
              Quên mật khẩu
            </a>
          </div>

          <Form.Item>
            <button type="submit" className="btn-custom">
              Đăng nhập
            </button>
          </Form.Item>
        </Form>
      </div>

      {/* Popup đăng nhập thành công */}
      <Modal
        open={isModalVisible}
        footer={null}
        closable={false}
        centered
        zIndex={20}
        width={420}
        className="custom-modal"
      >
        <div className="modal-content">
          <RiVerifiedBadgeFill
            color="green"
            // style={{ height: 100, width: 100 }}
            size={100}
          />
          <h2>Đăng nhập thành công!</h2>
          <p>Hệ thống sẽ chuyển trang trong giây lát...</p>
        </div>
      </Modal>
    </div>
  );
}

export default SignInPage;
