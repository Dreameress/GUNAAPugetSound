import React from 'react';
import { Link } from 'react-router-dom';
import { Formik, Field, Form, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import Icon from './../../atoms/Icon';

import { accountService } from './../../../services/account.service';
import { alertService } from './../../../services/alert.service';

function Login({ history, location }) {
    const initialValues = {
        email: '',
        password: ''
    };

    const validationSchema = Yup.object().shape({
        email: Yup.string()
            .email('Email is invalid')
            .required('Email is required'),
        password: Yup.string().required('Password is required')
    });

    function onSubmit({ email, password }, { setSubmitting }) {
        alertService.clear();
        accountService.login(email, password)
            .then(() => {
                const { from } = window.location.state || { from: { pathname: "/" } };
                history.push(from);
            })
            .catch(error => {
                setSubmitting(false);
                alertService.error(error);
            });
    }

    return (
        <Formik initialValues={initialValues} validationSchema={validationSchema} onSubmit={onSubmit}>
            {({ errors, touched, isSubmitting }) => (
                <Form style={{border: '3px solid #ECC954', padding: 20, maxWidth: 400, margin: '0 auto'}}>
                    <h3 className="card-header text-center">LOGIN</h3>
                    <div className="card-body">
                        <div className="form-group">
                            <label>EMAIL</label>
                            <Field name="email" type="text" className={'form-control' + (errors.email && touched.email ? ' is-invalid' : '')} />
                            <ErrorMessage name="email" component="div" className="invalid-feedback" />
                        </div>
                        <div className="form-group">
                            <label>PASSWORD</label>
                            <Field name="password" type="password" className={'form-control' + (errors.password && touched.password ? ' is-invalid' : '')} />
                            <ErrorMessage name="password" component="div" className="invalid-feedback" />
                        </div>
                        <div className="form-row">
                            <div className="form-group col text-center"  >
                                <button type="submit" disabled={isSubmitting} className="btn btn-default-gold">
                                    {isSubmitting && <span className="spinner-border spinner-border-sm mr-1"></span>}
                                    Login
                                    <Icon login  style={{ fontSize: 10, marginLeft: 5 }}  />
                                </button>
                                <Link to="register" className="btn ">REGISTER </Link>
                            </div>
                            <br />
                            <div className="form-group col text-center">
                                <Link to="forgot-password" className="btn pr-0">FORGOT PASSWORD?</Link>
                            </div>
                        </div>
                    </div>
                </Form>
            )}
        </Formik>
    )
}

export { Login }; 