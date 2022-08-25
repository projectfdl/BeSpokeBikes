import React, { Component } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

export class SaleList extends Component {
    static displayName = SaleList.name;

    constructor(props) {
        super(props);
        this.state = { data: [], loading: true, isOpen: false, formProductId: '' };
    }

    openModal = () => this.setState({ isOpen: true });
    closeModal = () => this.setState({ isOpen: false });

  

    componentDidMount() {
        this.populateData();
    }

    static renderDataTable(data) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Customer</th>
                        <th>Product</th>
                        <th>Salesperson</th> 
                        <th>Purchase Price</th>
                        <th>Commission Percent</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(item =>
                        <tr key={item.id}>
                            <td>{item.date}</td>
                            <td>{item.customer.firstName + ' ' + item.customer.lastName}</td>
                            <td>{item.product.name}</td>
                            <td>{item.salesperson.firstName + ' ' + item.salesperson.lastName}</td>
                            <td>{item.purchasePrice}</td>
                            <td>{item.commissionPercent}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : SaleList.renderDataTable(this.state.data);

        return (
            <div>
                <div class="container">
                    <div class="float-start">
                        <h2 id="tabelLabel">Sales</h2>
                    </div>
                    
                    <button type="button" class="btn btn-success float-end" onClick={this.openModal}>New Sale</button>                
                </div>
                <div>{contents}</div>

                <Modal show={this.state.isOpen}>
                    <Modal.Header>
                        <Modal.Title>Create Sale</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>Here's an empty modal that should have a bunch of fields</Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={this.closeModal}>
                            Close
                        </Button>
                        <Button variant="primary" onClick={this.submit}>
                            Submit
                        </Button>
                    </Modal.Footer>
                </Modal>
            </div>
        );
    }

    async populateData() {

        const response = await fetch('/api/sale');

        console.log(response);

        const data = await response.json();

        this.setState({ data: data, loading: false });
    }

    async loadProducts() {

    }

    submit = () => {
        this.closeModal();
    }

}
