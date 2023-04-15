import React, { useState, useEffect } from "react";
import {
  Table,
  Input,
  Button,
  Space,
  Form,
  Row,
  Col,
  Modal,Select,
  notification,
  Drawer,Empty
} from "antd";
import {
  EditFilled,
  CloseCircleOutlined,
  
} from "@ant-design/icons";
import axios from "axios";
import api from "../../services/api";
const MyCar = () => {
  const [data, setData] = useState([]);
  const [searchText, setSearchText] = useState("");
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [form] = Form.useForm();
  
  const [form1] = Form.useForm();
  const [open, setOpen] = useState(false);
  const [open1, setOpen1] = useState(false);
  const [modal, setModal] = useState({
    isOpen: false,
    data: {},
  });
  const [carModel,setCarModel]=useState([]);
  //const [loadings, setLoadings] = useState([]);
//   const enterLoading = (index) => {
//     setLoadings((state) => {
//       const newLoadings = [...state];
//       newLoadings[index] = true;
//       return newLoadings;
//     });
//     setTimeout(() => {
//       setLoadings((state) => {
//         const newLoadings = [...state];
//         newLoadings[index] = false;
//         return newLoadings;
//       });
//     }, 6000);
//   };

  const columns = [
    {
      title: "ID",
      dataIndex: "id",
      key: "id",
     
    },
    {
      title: "CarNumber",
      dataIndex: "carNumber",
      key: "carNumber",
      sorter: (a, b) => {
        if (a.carNumber > b.carNumber) {
          return -1;
        } else if (b.carNumber > a.carNumber) {
          return 1;
        }
        return 0;
      },
      
    },
    {
      title: "Model",
      dataIndex: "model",
      key: "model",
      sorter: (a, b) => {
        if (a.model > b.model) {
          return -1;
        } else if (b.model > a.model) {
          return 1;
        }
        return 0;
      },
     
    },
    {
      title: "Discript",
      dataIndex: "discript",
      key: "discript",
    },
    {
      title: "Action",
      dataIndex: "action",
      key: "action",
    },
  ];

  const showDrawer1 = () => {
    setOpen1(true);
  };
  const onClose1 = () => {
    setOpen1(false);
  };
  const [idcar, setIdCar] = useState("");
  useEffect(() => {
    api
      .get(`cars`, {})
      .then(function (response) {
        let respData = response.data;
        console.log(respData);

        respData.forEach((element) => {
          element.model = element.carModel.model;
          element.discript = element.carModel.discript;
         
          element.action = [
            <EditFilled
              style={{ fontSize: "25px" }}
              onClick={() => {
                showDrawer1();
                form1.setFieldsValue({
                  carModelID: element.carModel.id,
                  carNumber: element.carNumber,
                
                });
            
                setIdCar(element.id);
              }}
            />,

            <CloseCircleOutlined
              onClick={() => {
                Modal.confirm({
                  title: "Bạn chắc chứ ?",
                  icon: <CloseCircleOutlined style={{ color: "red" }} />,
                  content: "Bạn muốn xóa thông tin của xe này ? ",
                  okText: "Xóa",
                  cancelText: "Hủy",
                  okButtonProps: {
                    style: { background: "#e30c18", color: "white" },
                  },

                  onOk() {
                    return new Promise((resolve, reject) => {
                      setTimeout(Math.random() > 0.5 ? resolve : reject, 1000);
                      axios
                        .delete(
                          `${process.env.REACT_APP_Backend_URI}car/${element.id}`
                        )
                        .then(() => {
                          notification.success({
                            message: `Xóa thành công`,
                            description: "Delete a new car model successfully",
                            placement: "topLeft",
                          });
                        })
                        .catch(() => {
                          notification.error({
                            message: `Xóa không thành công`,
                            description: "Delete a user fail",
                            placement: "topLeft",
                          });
                        });
                      
                    });
                  },
                  onCancel() {},
                });
              }}
              style={{ color: "red", fontSize: "25px", marginLeft: "10px" }}
            />,
          ];
        });
        setData(
          respData.sort((a, b) => {
            if (a.model.trim().toLowerCase() > b.model.trim().toLowerCase()) {
              return 1;
            }
            if (b.model.trim().toLowerCase() > a.model.trim().toLowerCase()) {
              return -1;
            }
            return 0;
          })
        );
      }, [])
      .catch(() => {});
  }, [data, form1]);
  useEffect(() => {
    api.get(`carmodels`)
    .then(function(response){
        setCarModel(response.data);
      }).catch((e)=>{notification.warning({
        message: `Lỗi dữ liệu`,
        description: "Tải dữ liệu bị lỗi",
        placement: "topLeft",
      });});
}, [])
  const finalData =
    searchText === ""
      ? data
      : data.filter((u) =>
          u.carNumber
            .toLowerCase()
            .replace(/\s+/g, "")
            .includes(searchText.toLowerCase().replace(/\s+/g, ""))
        );

  const pagination = {
    current: page,
    PageSize: pageSize,
    total: finalData.length,
    pageSizeOptions: [5, 10, 15, 20],
    className: "ant-btn-dangerous",
    dangerous: true,
    onChange: (page, pageSize) => {
      setPage(page);
      setPageSize(pageSize);
    },
    showSizeChanger: true,
    showTotal: (total) => `Total ${total} Student`,
  };
  const showDrawer = () => {
    setOpen(true);
  };
  const onClose = () => {
    setOpen(false);
  };

  const onFinish = (values) => {
    api
      .post(`car`, {
        carModelID: values.carModelID,
        carNumber: values.carNumber,
       
      })
      .then(() => {
        onClose();
        notification.success({
          message: `Thành công`,
          description: "Create new car successfully",
          placement: "center",
        });

        form.setFieldsValue({
          carModelID : "",
          carNumber: "",
        });
        setOpen(false);
      
      })
      .catch((error) => {
        notification.warning({
          message: `Fail`,
          description: "Please check input again",
          placement: "center",
        });
        form.setFieldsValue({
          carNumber: "",
        });
      });

      
  };
  const onFinishEdit = (values) => {
    api
      .put(`car/${idcar}`, {
        carModelID: values.carModelID,
        carNumber: values.carNumber,

        
      })
      .then(() => {
        // sessionStorage.setItem("changeStatus", true);
        notification.success({
          message: `Thành công`,
          description: "Edit this car successfully",
          placement: "topLeft",
        });
        form.setFieldsValue({
          carNumber: "",
          carModelID: "",
         
        });
        setOpen(false);
        // window.location.reload();
      })
      .catch((error) => {
        notification.warning({
          message: `Fail`,
          description: "Please check input again",
          placement: "topLeft",
        });
        form.setFieldsValue({
          carNumber: "",
          carModelID: "",
        });
      });
  };
  return (
    <>
      <p
        style={{
          display: "block",
          fontSize: "20px",
          margin: "0 auto",
          textAlign: "left",
          color: " red",
          fontWeight: "bold",
          paddingBottom: "20px",
        }}
      >
        Car List
      </p>
      <Row gutter={45} style={{ marginBottom: "30px" }}>
        <Col xs={8} sm={8} md={7} lg={7} xl={6} xxl={5}>
          {/*Filter Role */}
         
        </Col>
        <Col xs={8} sm={8} md={7} lg={7} xl={8} xxl={8}>
          <Input.Search
            placeholder="Tìm thông tin xe"
            maxLength={255}
            allowClear
            onSearch={(e) => {
              setPage(1);
              setSearchText(e.replace(/ /g, ""));
            }}
          />
        </Col>
        <Col xs={8} sm={8} md={7} lg={7} xl={9} xxl={9}>
          <Button
            style={{ background: "#33CCFF", color: "white" }}
            onClick={() => {
              showDrawer();
              form.setFieldsValue({
                carNumber: "",
                model: "",
               
               
              });
            }}
          >
            Thêm xe 
          </Button>
        </Col>
      </Row>
     

      <Modal
        open={modal.isOpen}
        title="Detail Car model"
        onOk={() => {
          setModal({ ...modal, isOpen: false });
        }}
        style={{ width: 400 }}
        footer={[
          <Button
            style={{ background: "#e30c18", color: "white" }}
            key="back"
            onClick={() => {
              setModal({ ...modal, isOpen: false });
            }}
          >
            Close
          </Button>,
        ]}
        closable={false}
      >
        <table>
          <tr>
            <td style={{ width: "50px", fontSize: "18px", color: "#838688" }}>
              Mã xe
            </td>
            <td
              style={{
                fontSize: "18px",
                color: "#838688",
                textAlign: "justify",
                paddingLeft: "35px",
              }}
            >
              {modal.data.id}
            </td>
          </tr>
          <tr>
            <td style={{ width: "50px", fontSize: "18px", color: "#838688" }}>
              Biển số xe
            </td>
            <td
              style={{
                fontSize: "18px",
                color: "#838688",
                textAlign: "justify",
                paddingLeft: "35px",
              }}
            >
              {modal.data.carNumber}
            </td>
          </tr>
          <tr>
            <td style={{ width: "50px", fontSize: "18px", color: "#838688" }}>
              Loại xe
            </td>
            <td
              style={{
                fontSize: "18px",
                color: "#838688",
                textAlign: "justify",
                paddingLeft: "35px",
              }}
            >
              {modal.data.model}
            </td>
          </tr>
          <tr>
            <td style={{ width: "50px", fontSize: "18px", color: "#838688" }}>
              Mô tả
            </td>
            <td
              style={{
                fontSize: "18px",
                color: "#838688",
                textAlign: "justify",
                paddingLeft: "35px",
              }}
            >
              {modal.data.discript}
            </td>
          </tr>

          
        </table>
      </Modal>

      {data.length === 0 ? (
          <Empty description={"Không có dữ liệu"}/>
      ) : (
    
        <Table
          key="id"
          rowKey={(data) => data.id}
          columns={columns}
          pagination={pagination}
          dataSource={finalData}
          onRow={(record) => {
            return {
              onClick: (e) => {
                if (
                  e.target.className ===
                  "ant-table-cell ant-table-cell-row-hover"
                ) {
                  setModal({
                    ...modal,
                    isOpen: true,
                    data: {
                      id: record.id,
                      carNumber: record.carNumber,
                      model: record.model,
                      discript: record.discript,
                      
                    },
                  });
                  console.log(modal.data);
                } else if (
                  e.target.className ===
                  "ant-table-cell ant-table-column-sort ant-table-cell-row-hover"
                ) {
                  setModal({
                    ...modal,
                    isOpen: true,
                    data: {
                      id: record.id,
                      model: record.model,

                      discript: record.discript,
                     
                    },
                  });
                  console.log(modal.data);
                } else {
                  setModal({ ...modal, isOpen: false });
                }
              },
            };
          }}
        />
      )}
      {/*Add new car model */}
      <Drawer
        title="Thêm xe mới"
        width={550}
        onClose={onClose}
        open={open}
        bodyStyle={{
          paddingBottom: 80,
        }}
      >
        <Form
          form={form}
          onFinish={onFinish}
          layout="vertical"
          hideRequiredMark
        >
          <Row gutter={16}>
            <Col span={24}>
            <Form.Item
                name="carModelID"
                label="Loại xe"
                rules={[
                  {
                    required: true,
                    message: "Please enter Car model id",
                  },
                ]}
              >
            <Select
          placeholder="Chọn bãi đỗ"
           
          virtual={false}
          >
            
            {carModel.map((u)=> (
                      <option value={u.id}>
                        {u.model}
                      </option>
                    ))}
          </Select>
          </Form.Item>
              
            </Col>
          </Row>
    
          <Row gutter={16}>
            <Col span={24}>
              <Form.Item
                name="carNumber"
                label="Biển số xe"
                rules={[
                  {
                    required: true,
                    message: "Please enter car number ",
                  },
                ]}
              >
                <Input
                  style={{
                    width: "100%",
                  }}
                  placeholder="Please enter car number "
                />
              </Form.Item>
            </Col>
          </Row>

          <Row gutter={16}>
            <Col span={24}>
              <Space>
                <Button
                  onClick={() => {
                    onClose();
                    form.setFieldsValue({
                      model: "",
                      discript: "",
                     
                    });
                  }}
                >
                  Cancel
                </Button>
                <Button htmlType="submit" type="primary">
                  Submit
                </Button>
              </Space>
            </Col>
          </Row>
        </Form>
      </Drawer>
      {/*Edit car model */}
      <Drawer
        title="Sửa thông tin của xe"
        width={550}
        onClose={onClose1}
        open={open1}
        bodyStyle={{
          paddingBottom: 80,
        }}
      >
       
        <Form
          form={form1}
          onFinish={onFinishEdit}
          layout="vertical"
          hideRequiredMark
        >
          <Row gutter={16}>
            <Col span={24}>
            <Form.Item
                name="carModelID"
                label="Loại xe"
                rules={[
                  {
                    required: true,
                    message: "Please enter Car model id",
                  },
                ]}
              >
            <Select
          placeholder="Chọn bãi đỗ"
           
          virtual={false}
          >
            
            {carModel.map((u)=> (
                      <option value={u.id}>
                        {u.model}
                      </option>
                    ))}
          </Select>
          </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={24}>
              <Form.Item
                name="carNumber"
                label="Car Number"
                rules={[
                  {
                    required: true,
                    message: "Please enter Car Number",
                  },
                ]}
              >
                <Input placeholder="Please enter Car Number" />
              </Form.Item>
            </Col>
          </Row>

          <Row gutter={16}>
            <Col span={24}>
              <Space>
                <Button
                  onClick={() => {
                    onClose1();
                  }}
                >
                  Cancel
                </Button>
                <Button onClick={onClose1} htmlType="submit" type="primary">
                  Submit
                </Button>
              </Space>
            </Col>
          </Row>
        </Form>
      </Drawer>
    </>
  );
};

export default MyCar;