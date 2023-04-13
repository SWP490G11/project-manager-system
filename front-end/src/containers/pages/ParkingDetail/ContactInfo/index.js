import React from "react";
import { Divider,Collapse } from 'antd';
const {Panel} =Collapse;
const ContactInfo = (props) => {

    const parkingOwner = props.parking?.owner;
    const parkingManagers = props.parking?.parkingManagers

    return (
        <>
            <div style={{ marginBottom: '1rem' }}>
                <div style={{ fontWeight: '700', fontSize: '1.3rem',color:'red' }}>Chủ sở hữu</div>
                <div style={{ marginLeft: '1rem', fontSize: '1.1rem' }}>{`${parkingOwner?.firstName} ${parkingOwner?.lastName}`}</div>
                <div style={{ marginLeft: '1rem' }}><span style={{ fontWeight: 'bolder' }}>SDT: </span> {parkingOwner?.phoneNumber}</div>
                <div style={{ marginLeft: '1rem' }}><span style={{ fontWeight: 'bolder' }}>Email: </span> {parkingOwner?.email}</div>
            </div>
            <div>
                
                  
                    <Collapse >
                             <Panel header="Nhân viên quản lý" key="1" >
                             {parkingManagers?.map((data, key) => (
                    <div key={key}>
                        <div style={{ marginLeft: '1rem', fontSize: '1.1rem' }}>{`${data?.firstName} ${data?.lastName}`}</div>
                        <div style={{ marginLeft: '1rem' }}><span style={{ fontWeight: 'bolder' }}>SĐT: </span> {data?.phoneNumber}</div>
                        <div style={{ marginLeft: '1rem' }}><span style={{ fontWeight: 'bolder' }}>Email: </span> {data?.email}</div>
                        <Divider dashed />
                    </div>
                ))}
                              </Panel>
      
   
    </Collapse>
                
            </div>

        </>
    )
}

export default ContactInfo;