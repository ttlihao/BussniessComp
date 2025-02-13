import React, { useState } from "react";
import axios from "axios";
import { Form, Input, message, Modal } from "antd";
import "./ForgotPasswordPage.scss";
import { RiVerifiedBadgeFill } from "react-icons/ri";
import { useNavigate } from "react-router-dom";

function ForgotPasswordPage() {
  const navigate = useNavigate();
  const [step, setStep] = useState(1); // 1: Nhập email, 2: Nhập OTP, 3: Đổi mật khẩu
  const [email, setEmail] = useState("");
  const [otp, setOtp] = useState("");
  const [isModalVisible, setIsModalVisible] = useState(false);

  // 🔹 Gửi email để nhận OTP
  const handleSendEmail = async (values) => {
    try {
      const response = await axios.post(
        "https://localhost:7240/api/authenticate/forgot-password",
        {
          email: values.email,
        }
      );
      if (response.status === 200) {
        message.success("Đã gửi OTP đến email của bạn!");
        setEmail(values.email);
        setStep(2);
      }
    } catch (error) {
      message.error("Lỗi khi gửi email! Vui lòng thử lại.");
    }
  };

  // 🔹 Xác minh OTP
  const handleVerifyOTP = async (values) => {
    try {
      const response = await axios.post(
        `https://localhost:7240/api/authenticate/verify-otp?email=${email}&otp=${values.otp}`
      );
      if (response.data.succeeded) {
        message.success("Xác minh OTP thành công!");
        setOtp(values.otp);
        setStep(3);
      } else {
        message.error("Mã OTP không đúng! Vui lòng thử lại.");
      }
    } catch (error) {
      message.error("Lỗi khi xác minh OTP!");
    }
  };

  // 🔹 Đặt lại mật khẩu
  const handleResetPassword = async (values) => {
    try {
      const response = await axios.post(
        "https://localhost:7240/api/authenticate/reset-password",
        {
          email,
          otp,
          newPassword: values.password,
          confirmPassword: values.confirm,
        }
      );

      if (response.data.succeeded) {
        setIsModalVisible(true);

        setTimeout(() => {
          setIsModalVisible(false);
          navigate("/sign-in");
        }, 2000);
      }
    } catch (error) {
      message.error("Lỗi khi đổi mật khẩu! Vui lòng thử lại.");
    }
  };

  return (
    <div className="mt-[82px] fpp-container">
      {step === 1 && (
        <div className="fpp-wrapper">
          <h1>Quên mật khẩu</h1>
          <p>Vui lòng nhập email của bạn để đặt lại mật khẩu</p>
          <Form
            name="forgot-pass-email"
            layout="vertical"
            onFinish={handleSendEmail}
          >
            <Form.Item
              name="email"
              className="form-custom"
              rules={[
                { required: true, message: "Vui lòng nhập email!" },
                { type: "email", message: "Email không hợp lệ!" },
              ]}
            >
              <Input
                placeholder="Nhập email"
                className="form-input"
                autoComplete="email"
              />
            </Form.Item>
            <Form.Item>
              <button type="submit" className="btn-custom mt-3">
                Đặt lại mật khẩu
              </button>
            </Form.Item>
          </Form>
        </div>
      )}

      {step === 2 && (
        <div className="fpp-wrapper">
          <h1>Kiểm tra Email</h1>
          <p>
            Chúng tôi đã gửi liên kết đặt lại đến <b>{email}</b> <br />
            Nhập mã 5 chữ số được gửi trong email
          </p>
          <Form
            name="forgot-pass-otp"
            layout="vertical"
            onFinish={handleVerifyOTP}
          >
            <Form.Item
              name="otp"
              className="form-custom"
              rules={[{ required: true, message: "Vui lòng nhập OTP!" }]}
            >
              <Input
                placeholder="Nhập OTP"
                className="form-input"
                autoComplete="one-time-code"
              />
            </Form.Item>
            <Form.Item>
              <button type="submit" className="btn-custom mt-3">
                Xác minh mã
              </button>
            </Form.Item>
          </Form>
          <p>
            Bạn vẫn chưa nhận được email?{" "}
            <a onClick={() => handleSendEmail({ email })}>Gửi lại</a>
          </p>
        </div>
      )}

      {step === 3 && (
        <div className="fpp-wrapper">
          <h1>Đặt lại mật khẩu mới</h1>
          <p>
            Tạo mật khẩu mới. Đảm bảo mật khẩu này khác với mật khẩu trước đó để
            bảo mật.
          </p>
          <Form
            name="forgot-pass-change"
            layout="vertical"
            onFinish={handleResetPassword}
          >
            <Form.Item
              name="password"
              className="form-custom"
              rules={[
                { required: true, message: "Vui lòng nhập mật khẩu!" },
                { min: 8, message: "Mật khẩu phải có ít nhất 8 ký tự!" },
                { max: 20, message: "Mật khẩu không được vượt quá 20 ký tự!" },
                {
                  pattern: /[A-Z]/,
                  message: "Mật khẩu phải chứa ít nhất 1 chữ in hoa!",
                },
                {
                  pattern: /[a-z]/,
                  message: "Mật khẩu phải chứa ít nhất 1 chữ thường!",
                },
                {
                  pattern: /\d/,
                  message: "Mật khẩu phải chứa ít nhất 1 chữ số!",
                },
                {
                  pattern: /[\W_]/,
                  message: "Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt!",
                },
              ]}
            >
              <Input.Password
                placeholder="Nhập mật khẩu"
                className="form-input"
                autoComplete="new-password"
              />
            </Form.Item>

            <Form.Item
              name="confirm"
              className="form-custom"
              dependencies={["password"]}
              rules={[
                { required: true, message: "Vui lòng nhập lại mật khẩu!" },
                ({ getFieldValue }) => ({
                  validator(_, value) {
                    if (!value || getFieldValue("password") === value) {
                      return Promise.resolve();
                    }
                    return Promise.reject(
                      new Error("Mật khẩu xác nhận không khớp!")
                    );
                  },
                }),
              ]}
            >
              <Input.Password
                placeholder="Nhập lại mật khẩu"
                className="form-input"
                autoComplete="new-password"
              />
            </Form.Item>

            <Form.Item>
              <button type="submit" className="btn-custom mt-3">
                Cập nhật mật khẩu
              </button>
            </Form.Item>
          </Form>
        </div>
      )}
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
          <RiVerifiedBadgeFill color="green" size={100} />
          <h2>Đặt lại mật khẩu thành công!</h2>
          <p>
            Xin chúc mừng! Mật khẩu của bạn đã được thay đổi. Hệ thống sẽ chuyển
            trang trong giây lát...
          </p>
        </div>
      </Modal>
    </div>
  );
}

export default ForgotPasswordPage;
